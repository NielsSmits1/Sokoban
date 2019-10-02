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
            IsEmpty = false;
        }

        public override bool IsEmpty
        {
            get
            {
                return _isEmpty;
            }
            set
            {
                if(value == true)
                {
                    _isEmpty = value;
                    _symbol = ' ';
                }
                else
                {
                   _isEmpty = value;
                }
               
            }
        }


        public override char Symbol
        {
            get
            {
                if(containsItem != null)
                {
                    return containsItem.Symbol;
                }
                return _symbol;
            }

            set
            {
                _symbol = value;
            }
        }

        public override void SetItem(MoveableObject item, string direction)
        {
            if(containsItem == null)
            {
                containsItem = item;
                containsItem.MoveableSpot = this;
                return;
            }else if(containsItem.IsColleague == false && item.IsColleague == false && item.MoveableSpot.GetSpotInOppositeDirection(direction).ContainsItem.IsColleague == true)
            {

                getSpotInDirection(direction).SetItem(ContainsItem, direction);
                containsItem = item;
                containsItem.MoveableSpot = this;
                return;
            }else if(containsItem.IsCrate == true && item.IsCrate == true)
            {
                throw new Exception_TwoCratesInARow();
            }else if(containsItem.IsColleague == true)
            {
                throw new Exception_HitColleague();
            }
            if(containsItem.IsCrate == true && item.IsCrate == false)
            {
                getSpotInDirection(direction).SetItem(ContainsItem, direction);
                containsItem = item;
                containsItem.MoveableSpot = this;
            }
        }

        protected Spot getSpotInDirection(string direction)
        {
            switch (direction)
            {
                case "down":
                    return DownSpot;
                case "up":
                    return UpSpot;
                case "right":
                    return RightSpot;
                case "left":
                    return LeftSpot;
            }
            return null;
        }

        
    }
}