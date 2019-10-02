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
            
        }

        public void getMapLocation(ConsoleKey key)
        {

            switch (key)
            {
                case ConsoleKey.D1:
                    createMap(Resources.doolhof1);
                    break;
                case ConsoleKey.D2:
                    createMap(Resources.doolhof2);
                    break;
                case ConsoleKey.D3:
                    createMap(Resources.doolhof3);
                    break;
                case ConsoleKey.D4:
                    createMap(Resources.doolhof4);
                    break;
                case ConsoleKey.D5:
                    createMap(Resources.doolhof5);
                    break;
                case ConsoleKey.D6:
                    createMap(Resources.doolhof6);
                    break;
                case ConsoleKey.S:
                    Stop();
                    break;
                default:
                    _outputview.ErrorMessageSelectingMap();
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
            //Random r = new Random();
            //_outputview.printLine("" + r.Next(1, 5));
            //_outputview.printLine("" + r.Next(1, 5));
            //_outputview.printLine("" + r.Next(1, 5));
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
            _game.Move(direction);
        }

        public void Play()
        {
            
            
            while(_game.Winner == false && Cancel == false)
            {
                

                    _inputview.DirectionalInput();
                    _outputview.ClearConsole();
                    PrintMaze(); 
                

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
