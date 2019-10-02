using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    public class Trap : Floor
    {
        private int _breakCounter;
        public Trap()
        {
            _symbol = '~';
            _breakCounter = 0;
        }

        public override void SetItem(MoveableObject item, string direction)
        {
            if(_breakCounter == 3)
            {
                if (containsItem == null && item.IsCrate == false)
                {
                    containsItem = item;
                    containsItem.MoveableSpot = this;
                    return;
                }
                if (containsItem == null && item.IsCrate == true)
                {
                    return;
                }
                if (containsItem.IsCrate == true && item.IsCrate == true)
                {
                    throw new Exception_TwoCratesInARow();
                }
                if (containsItem.IsCrate == true && item.IsCrate == false)
                {
                    getSpotInDirection(direction).SetItem(ContainsItem, direction);
                    containsItem = item;
                    containsItem.MoveableSpot = this;
                }
            }
            else
            {
                base.SetItem(item, direction);
                _breakCounter++;
                if(_breakCounter == 3)
                {
                    Symbol = ' ';
                }
            }
            
        }
    }
}
