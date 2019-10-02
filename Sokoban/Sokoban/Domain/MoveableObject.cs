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

        public void Move(Spot newSpot)
        {
            _spot = newSpot;
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
    }
}