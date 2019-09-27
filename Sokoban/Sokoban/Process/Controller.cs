using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Presentation;
using Sokoban.Domain;

using System.Windows.Forms;
using Sokoban.Properties;

namespace Sokoban.Process
{
    class Controller
    {

        private Game _game;
        private Inputview _inputview;
        private Outputview _outputview;
        private bool winner;
        public bool Cancel { get; set; } = false;
        public Controller()
        {
            _game = new Game();
            _outputview = new Outputview();
            _inputview = new Inputview(this);
            _outputview.StartOfGame();
            _inputview.Begin();
           // string sFileName = "";
                //Console.WriteLine(Parse.FileToCharArray(sFileName));
            
        }

        public void getMapLocation(string mapNumber)
        {
            switch (mapNumber)
            {
                case "1":
                    createMap(Resources.doolhof1);
                    break;
                case "2":
                    createMap(Resources.doolhof2);
                    break;
                case "3":
                    createMap(Resources.doolhof3);
                    break;
                case "4":
                    createMap(Resources.doolhof4);
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
            PrintMaze();
            Play();
        }

        public void PrintMaze()
        {
            Spot current = _game.Maze.First;
            Spot firstTileLine = current;

            while (current != null)
            {
                 _outputview.printSymbol(current.Symbol);
                

                if (current.RightSpot == null)
                {
                    _outputview.printNewLine();
                    current = firstTileLine.DownSpot;
                    firstTileLine = current;
                }
                else
                {
                    current = current.RightSpot;
                }
            }

            
        }

        public void Move(string direction)
        {
            if (direction.Equals("s"))
            {
                Stop();
            }
            _game.Move(direction);
        }

        public void Play()
        {
            
            
            while(_game.Winner == false && Cancel == false)
            {
                try
                {

                    _inputview.DirectionalInput();
                    _outputview.ClearConsole();
                    PrintMaze(); 
                }
                catch (Exception_CanNotMoveIntoWall)
                {
                    _outputview.ErrorMessageMoveIntoWall();
                    
                }
                catch (Exception_TwoCratesInARow)
                {
                    _outputview.ErrorMessageMoveTwoCrates();
                }
                
            }
            if(_game.Winner == true)
            {
                _outputview.WinMessage();
                _inputview.Stop();
            }
            else
            {
                _inputview.Stop();
            }
            
            
        }

        public void Stop()
        {
            Application.Exit();
        }
    }
}
