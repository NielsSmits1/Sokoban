using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Domain
{
    public abstract class Spot
    {
        protected char _symbol;
        protected MoveableObject containsItem;
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

        virtual public MoveableObject ContainsItem
        {
            get
            {
                return containsItem;
            }
            set
            {
                containsItem = value;
            }
        }

        abstract public void SetItem(MoveableObject item, string direction);
        

        
    }
}