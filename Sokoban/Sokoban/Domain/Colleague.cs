using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    public class Colleague : MoveableObject
    {
        private bool _isSleeping;
        private Random r;
        public Colleague(Spot spot)
        {
            Symbol = '$';
            _spot = spot;
            isCrate = false;
            isTruck = false;
            isColleague = true;
            _isSleeping = false;
            r = new Random();

        }

        public override void WakeUpColleague()
        {
            _isSleeping = false;
            Symbol = '$';
        }

        public void Move()
        {
            WakeUp();
            BedTime();
            if (!_isSleeping)
            {
                int direction = r.Next(1, 5);
                switch (direction)
                {
                    case 1:
                        base.Move("down");
                        break;
                    case 2:
                        base.Move("up");
                        break;
                    case 3:
                        base.Move("right");
                        break;
                    case 4:
                        base.Move("left");
                        break;
                }
            }
        }

        private void BedTime()
        {
            if (_isSleeping)
            {
                return;
            }
            int random = r.Next(1, 5);
            if(random == 1)
            {
                _isSleeping = true;
                Symbol = 'Z';
            }
        }

        private void WakeUp()
        {
            if (!_isSleeping)
            {
                return;
            }
            int random = r.Next(1, 11);
            if(random == 1)
            {
                _isSleeping = false;
                Symbol = '$';
            }
        }
    }
}
