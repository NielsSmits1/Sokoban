using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Domain
{
    public class Floor : Spot
    {
        public Floor()
        {
            _symbol = '.';
            _magBezetWorden = true;
        }

        public virtual void move()
        {

        }
        
    }
}