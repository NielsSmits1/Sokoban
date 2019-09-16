using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Presentation;
using Sokoban.Domain;
using System.Windows.Forms;

namespace Sokoban.Process
{
    class Controller
    {

        private Game _game;
        private Inputview _inputview;
        private Outputview _outputview;


        public Controller()
        {
            _game = new Game();
            _outputview = new Outputview();
            _inputview = new Inputview(this);
            _outputview.Begin();
            _inputview.Begin();
           // string sFileName = "";
                //Console.WriteLine(Parse.FileToCharArray(sFileName));
            
        }

        public void getMapLocation(string mapNumber)
        {
            switch (mapNumber)
            {
                case "1":
                    createMap("C:\\Users\\NGAPA\\Documents\\INF\\Blok5\\MODL3\\Doolhof\\doolhof1.txt");
                    break;
                case "2":
                    createMap("C:\\Users\\NGAPA\\Documents\\INF\\Blok5\\MODL3\\Doolhof\\doolhof2.txt");
                    break;
                case "3":
                    createMap("C:\\Users\\NGAPA\\Documents\\INF\\Blok5\\MODL3\\Doolhof\\doolhof3.txt");
                    break;
                case "4":
                    createMap("C:\\Users\\NGAPA\\Documents\\INF\\Blok5\\MODL3\\Doolhof\\doolhof4.txt");
                    break;
                default:
                    _outputview.ErrorMessageSelectingMap();
                    _inputview.Begin();
                    break;
            }
        }

        public void createMap(string location)
        {
            Console.WriteLine("CreateMap is aangeroepen");
            string[] map = Parse.FileToStringArray(location);
            _game.createMaze(map);
            printMaze();
        }

        public void printMaze()
        {
            Spot current = _game.Maze.First;
            Spot firstTileLine = current;

            while (current != null)
            {
                if (current.Occupied != null)
                {
                    _outputview.printSymbol(current.Occupied.Symbol);
                }
                else
                {
                    _outputview.printSymbol(current.Symbol);
                }

                if (current.rightSpot == null)
                {
                    _outputview.printNewLine();
                    current = firstTileLine.downSpot;
                    firstTileLine = current;
                }
                else
                {
                    current = current.rightSpot;
                }
            }

            _inputview.Begin();
        }
    }
}
