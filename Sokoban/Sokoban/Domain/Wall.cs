using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Domain
{
    public class Wall : Spot
    {

        public Wall()
        {
            _symbol = '█';
            _magBezetWorden = false;
        }

        public override MoveableObject Occupied
        {
            get
            {
                return null;
            }
            set
            {
                throw new Exception_CanNotMoveIntoWall();
            }
        }
    }
}