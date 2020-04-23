using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Process;

namespace Sokoban.Presentation
{
    class Inputview
    {
        private Controller _controller;
        public Inputview(Controller controller)
        {
            _controller = controller;
        }

        public void Begin()
        {
            ConsoleKey key = Console.ReadKey().Key;
            _controller.getMapLocation(key);
            //switch (key)
            //{
            //    case ConsoleKey.D1:
            //        _controller.getMapLocation("1");
            //        break;
            //    case ConsoleKey.D2:
            //        _controller.getMapLocation("2");
            //        break;
            //    case ConsoleKey.D3:
            //        _controller.getMapLocation("3");
            //        break;
            //    case ConsoleKey.D4:
            //        _controller.getMapLocation("4");
            //        break;
            //    case ConsoleKey.S:
            //        _controller.Stop();
            //        break;
            //    default:
            //        _controller.getMapLocation("");
            //        break;

            //}
            
        }

        public void DirectionalInput()
        {
            ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        _controller.Move("down");
                        break;
                    case ConsoleKey.UpArrow:
                        _controller.Move("up");
                        break;
                    case ConsoleKey.RightArrow:
                        _controller.Move("right");
                        break;
                    case ConsoleKey.LeftArrow:
                        _controller.Move("left");
                        break;
                    case ConsoleKey.S:
                    _controller.Cancel = true;
                    break;
                    default:
                        DirectionalInput();
                        break;

                }
        }

        public void Stop()
        {
            Console.ReadKey();
            _controller.Stop();
        }
    }
}
