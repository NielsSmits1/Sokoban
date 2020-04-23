using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    class Game
    {

        private Maze _maze { get; set; }
        public bool Winner { get; set; } = false;
       // private List<MoveableObject> _moveables;
        //private Truck _truck;

        public Game()
        {
           // _moveables = new List<MoveableObject>();
        }

        public void createMaze(string[] maze)
        {
            _maze = new Maze(maze);
        }

        public void Move(string direction)
        {
            try
            {
                _maze.Move(direction);
            }
            catch (Exception_HitColleague)
            {

            }
            catch (Exception_TwoCratesInARow)
            {

            }
            catch (Exception_CanNotMoveIntoWall)
            {

            }
            try
            {
                _maze.MoveColleague();
            }
            catch (Exception_CanNotMoveIntoWall)
            {

            }
            catch (Exception_TwoCratesInARow)
            {

            }
            
            checkForWinner();
        }

        private void checkForWinner()
        {
            if(_maze.AmountOfDestinationsContainingCrates() == _maze.AmountOfCrates())
            {
                Winner = true;
            }
            
        }

        public Maze Maze
        {
            get
            {
                return _maze;
            }
        }
    }
}
