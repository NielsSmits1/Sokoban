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
            _controller.getMapLocation(Console.ReadLine());
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
                    default:
                        DirectionalInput();
                        break;

                }
        }
    }
}
