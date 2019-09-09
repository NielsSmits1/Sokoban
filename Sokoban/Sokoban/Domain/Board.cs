using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Domain
{
    public class Board
    {
        private int _amountOfChars = 1;
        private Spot[] _bord;

        public Board()
        {
            _bord = new Spot[_amountOfChars];
        }
    }
}