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
        public bool Winner { get; set; } = false;
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
            checkForWinner();
        }

        private void checkForWinner()
        {
            foreach (Crate crate in _speelveld.Crates)
            {
                if (crate.Bestemming == false)
                {
                    return;
                }
            }
            Winner = true;
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
