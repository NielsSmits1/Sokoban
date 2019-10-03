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
            base.SetItem(item, direction);
            if (ContainsItem.IsCrate)
            {
                _crateOnDestination = true;
            }
            else
            {
                _crateOnDestination = false;
            }
        }
    }
}