using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Bets
{
    public class Buy : Place, IHasVig
    {
        public Buy(Table table) : base(table)
        {
        }

        public int Vig
        {
            get
            {
                int v = (int)Math.Floor(0.05 * Wager);
                return (v > 0) ? v : 1;
            }
        }

        internal override void ProcessRoll(Dice roll)
        {
            BetOutcome bo = new BetOutcome();

            //Need logic as to if bets are on or not
            if (roll.Total == Point)
            {
                bo.BetStatus = BetOutcome.Status.Win;
                switch (roll.Total)
                {
                    case 4 or 10:
                        bo.Payout = 2 * Wager;
                        break;
                    case 5 or 9:
                        bo.Payout = (1.5 * Wager).FuzzyFloor();
                        break;
                    case 6 or 8:
                        bo.Payout = (1.2 * Wager).FuzzyFloor();
                        break;
                    default:
                        throw new Exception("Unexpected roll point match.");
                }
            }
            else if (roll.Total == 7)
            {
                bo.BetStatus = BetOutcome.Status.Lose;
                bo.Payout = 0;
            }
            else
            {
                bo.BetStatus = BetOutcome.Status.NoAction;
                bo.Payout = 0;
            }

            BetOutcome = bo;
        }
    }
}
