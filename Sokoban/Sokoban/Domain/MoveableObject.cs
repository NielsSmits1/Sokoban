using Sokoban.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public abstract class MoveableObject
    {

        protected Spot _spot { get; set; }
        protected char _symbol;
        protected bool isCrate;
        protected bool isTruck;
        protected bool isColleague;
        public char Symbol
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

        public virtual Spot MoveableSpot
        {
            get
            {
                return _spot;
            }
            set
            {
                _spot = value;
            }
        }

        public bool IsCrate
        {
            get
            {
                return isCrate;
            }
        }

        public bool IsTruck
        {
            get
            {
                return isTruck;
            }
        }

        public bool IsColleague
        {
            get
            {
                return isColleague;
            }
        }

        public virtual void Move(string direction)
        {
            Spot current = MoveableSpot;
            switch (direction)
            {
                case "down":
                    MoveableSpot.DownSpot.SetItem(this, "down");
                    break;
                case "up":
                    MoveableSpot.UpSpot.SetItem(this, "up");
                    break;
                case "right":
                    MoveableSpot.RightSpot.SetItem(this, "right");
                    break;
                case "left":
                    MoveableSpot.LeftSpot.SetItem(this, "left");
                    break;
            }
            current.ContainsItem = null;
        }

        public abstract void WakeUpColleague();
    }
}