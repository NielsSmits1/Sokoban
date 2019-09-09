using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Domain
{
    public class Destination : Floor
    {

        public Destination()
        {
            _symbol = 'x';
            _magBezetWorden = true;
        }

        override public void move()
        {

        }
    }
}