using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Domain
{
    public class Crate : MoveableObject
    {
        private bool _onDestination;
       // private Spot huidigePlek;
        public Crate(Spot spot)
        {
            Symbol = 'o';
            _spot = spot;
            _onDestination = false;
        }
        
        public bool Bestemming
        {
            get
            {
                return _onDestination;
            }
            set
            {
                _onDestination = value;
            }
        }
    }
}