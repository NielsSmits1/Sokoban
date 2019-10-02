using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    public class Colleague : MoveableObject
    {
        public Colleague(Spot spot)
        {
            Symbol = '$';
            _spot = spot;
            isCrate = false;
            isTruck = false;
            isColleague = true;
        }
    }
}
