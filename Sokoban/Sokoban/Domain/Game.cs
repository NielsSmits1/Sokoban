using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    class Game
    {

        private Board _speelveld;
        private List<MoveableObject> _moveables;
        private LinkedList<Spot> _firstRow;
        //private Truck _truck;

        public Game(List<char[]> board)
        {
            _moveables = new List<MoveableObject>();
        }

        public void createBoard()
        {
            _firstRow = new LinkedList<Spot>();
        }
    }
}
