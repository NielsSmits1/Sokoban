using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Domain
{
    public class Truck : MoveableObject
    {
        
        //private Spot huidigePlek;
        public Truck(Spot spot)
        {
            Symbol = '@';
            _spot = spot;
            isCrate = false;
            isTruck = true;
            isColleague = false;
        }

        public override void WakeUpColleague()
        {
        }
    }
}