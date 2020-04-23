using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Domain
{
    public class Crate : MoveableObject
    {
       // private Spot huidigePlek;
        public Crate(Spot spot)
        {
            Symbol = 'o';
            _spot = spot;
            isCrate = true;
            isTruck = false;
            isColleague = false;
        }

        public override void WakeUpColleague()
        {
        }
    }
}