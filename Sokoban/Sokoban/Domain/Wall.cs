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
        }

        public override MoveableObject ContainsItem
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

        public override void SetItem(MoveableObject item, string direction)
        {
            throw new Exception_CanNotMoveIntoWall();
        }
    }
}