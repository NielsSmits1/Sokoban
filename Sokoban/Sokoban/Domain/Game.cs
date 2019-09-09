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
        //private Truck _truck;

        public Game()
        {
            moveables = new List<MoveableObject>();
        }
    }
}
