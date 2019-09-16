using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Domain
{
    public class Wall : Spot
    {

        public Wall()
        {
            _symbol = '#';
            _magBezetWorden = false;
        }
    }
}