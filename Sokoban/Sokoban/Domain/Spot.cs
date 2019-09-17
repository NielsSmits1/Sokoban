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
        protected MoveableObject occupied;
        virtual public char Symbol
        {
            get
            {
                return _symbol;
            }
            set
            {
                _symbol = value;
            }
        }
        virtual public Spot LeftSpot
        {
            get;
            set;
        }

        virtual public Spot RightSpot
        {
            get;
            set;
        }

        virtual public Spot UpSpot
        {
            get;
            set;
        }


        virtual public Spot DownSpot
        {
            get;
            set;
        }

        virtual public MoveableObject Occupied
        {
            get
            {
                return occupied;
            }
            set
            {
                occupied = value;
            }
        }
    }
}