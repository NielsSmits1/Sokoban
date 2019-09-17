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
        

        public override Spot MoveableSpot
        {
            get
            {
                return _spot;
            }
            set
            {
                if(value is Destination)
                {
                    Symbol = '0';
                    _onDestination = true;
                    _spot = value;
                }
                else
                {
                    Symbol = 'o';
                    _onDestination = false;
                    _spot = value;
                }
            }
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