using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Bets
{
    /// <summary>
    /// The Come bet, once the point is established you can put a bet in the 'Come'.
    /// This will win if a 7 or 11 is rolled, and lose if a 2, 3, or 12 is rolled.
    /// If none of those are rolled, the bet travels to the rolled number.
    /// Once on a point the bet wins if that number is rolled, and loses if a 7 is rolled.        
    /// This pays out 1:1 and is a contract bet
    /// </summary>
    public class Come : Bet, ICanHaveOdds
    {
        public Come(Table table) : base(table)
        {
        }

        public Table UnderlyingTable { get { return Game; } }

        public BetOutcome UnderlyingOutcome { get { return BetOutcome; } }

        protected internal int? Point { get; set; }

        internal override bool CanPlaceBet()
        {
            if (Game.PointEstablished)
                return true;
            return false;
        }

        internal override void ProcessRoll(Dice roll)
        {
            BetOutcome outcome = new BetOutcome();

            if (Point.HasValue)
            {
                if (roll.Total == Point.Value)
                {
                    outcome.BetStatus = BetOutcome.Status.Win;
                    outcome.Payout = 1 * Wager;
                }
                else if (roll.Total == 7)
                {
                    outcome.BetStatus = BetOutcome.Status.Lose;
                    outcome.Payout = 0;
                }
                else
                {
                    outcome.BetStatus = BetOutcome.Status.NoAction;
                    outcome.Payout = 0;
                }
            }
            else
            {
                // Still in come box
                switch (roll.Total)
                {
                    case 7 or 11:
                        outcome.BetStatus = BetOutcome.Status.Win;
                        outcome.Payout = 1 * Wager;
                        break;
                    case 2 or 3 or 12:
                        outcome.BetStatus = BetOutcome.Status.Lose;
                        outcome.Payout = 0;
                        break;
                    default:
                        outcome.BetStatus = BetOutcome.Status.NoAction;
                        outcome.Payout = 0;
                        Point = roll.Total; //move bet to point
                        break;
                }
            }

            BetOutcome = outcome;
        }
    }
}
