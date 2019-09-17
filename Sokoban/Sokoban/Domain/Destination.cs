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
        }

        override public void move()
        {

        }
    }
}