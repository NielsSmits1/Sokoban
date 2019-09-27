using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Domain
{
    public class Destination : Floor
    {

        private bool _crateOnDestination;

        public Destination()
        {
            _symbol = 'x';
        }

        public bool CrateOnDestination
        {
            get
            {
                return _crateOnDestination;
            }
        }

        public override char Symbol
        {
            get
            {
                if (containsItem != null)
                {
                    if(containsItem.IsCrate == true)
                    {
                        return '0';
                    }
                    return containsItem.Symbol;
                }
                return _symbol;
            }

            set
            {
                _symbol = value;
            }
        }

        public override void SetItem(MoveableObject item, string direction)
        {
            if (containsItem == null)
            {
                if(item.IsCrate == true)
                {
                    containsItem = item;
                    containsItem.MoveableSpot = this;
                    _crateOnDestination = true;
                }
                else
                {
                    containsItem = item;
                    containsItem.MoveableSpot = this;
                    _crateOnDestination = false;
                }
                
                return;
            }
            if (containsItem.IsCrate == true && item.IsCrate == true)
            {
                throw new Exception_TwoCratesInARow();
            }
            if (containsItem.IsCrate == true && item.IsCrate == false)
            {
                getSpotInDirection(direction).SetItem(ContainsItem, direction);
                if (item.IsCrate == true)
                {
                    containsItem = item;
                    containsItem.MoveableSpot = this;
                    _crateOnDestination = true;
                }
                else
                {
                    containsItem = item;
                    containsItem.MoveableSpot = this;
                    _crateOnDestination = false;
                }
                
            }
        }
    }
}