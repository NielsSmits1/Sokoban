using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Domain
{
    public class Crate : MoveableObject
    {
        private bool _isOpBestemming;
       // private Spot huidigePlek;
        public Crate()
        {
            _isOpBestemming = false;
        }
        
        public bool Bestemming
        {
            get
            {
                return _isOpBestemming;
            }
            set
            {
                _isOpBestemming = value;
            }
        }
    }
}