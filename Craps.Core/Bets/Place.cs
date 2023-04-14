using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Bets
{
    public class Place : Bet
    {
        public Place(Table table) : base(table) 
        { 
        }

        protected internal int Point { get; set; }

        internal override bool CanPlaceBet()
        {
            //Obviously this needs to be more complex with on-off and such
            if (Game.PointEstablished)
                return true;
            return false;
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
                        bo.Payout = (1.8 * Wager).FuzzyFloor();
                        break;
                    case 5 or 9:
                        bo.Payout = (1.4 * Wager).FuzzyFloor();
                        break;
                    case 6 or 8:
                        bo.Payout = (1.1667 * Wager).FuzzyFloor();
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
