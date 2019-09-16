using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Domain
{
    public abstract class Spot
    {
        protected char _symbol;
        protected bool _magBezetWorden;

        virtual public char LeftSpot
        {
            get;
            set;
        }

        virtual public char rightSpot
        {
            get;
            set;
        }

        virtual public char UpSpot
        {
            get;
            set;
        }


        virtual public char downSpot
        {
            get;
            set;
        }
    }
}