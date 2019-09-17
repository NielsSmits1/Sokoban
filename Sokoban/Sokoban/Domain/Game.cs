using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    class Game
    {

        private Maze _speelveld { get; set; }
       // private List<MoveableObject> _moveables;
        //private Truck _truck;

        public Game()
        {
           // _moveables = new List<MoveableObject>();
        }

        public void createMaze(string[] maze)
        {
            _speelveld = new Maze(maze);
        }

        public void Move(string direction)
        {
            _speelveld.Move(direction);
        }

        public Maze Maze
        {
            get
            {
                return _speelveld;
            }
        }
    }
}
