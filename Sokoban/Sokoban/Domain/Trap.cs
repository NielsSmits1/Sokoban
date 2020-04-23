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
                base.SetItem(item, direction);
                if (ContainsItem.IsCrate)
                {
                    ContainsItem.MoveableSpot = null;
                    ContainsItem = null;
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
