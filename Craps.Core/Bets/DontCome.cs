using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Bets
{
    /// <summary>
    /// The Don't Come bet, once the point is established you can put a bet in the 'Don't Come'.
    /// This will lose if a 7 or 11 is rolled, will win if a 2, 3 is rolled, and push if a 12 is rolled.
    /// If none of those are rolled, the bet travels to the rolled number.
    /// Once on a point the bet loses if that number is rolled, and wins if a 7 is rolled.
    /// This pays out 1:1 and is a contract bet
    /// </summary>
    public class DontCome : Come
    {
        public DontCome(Table table) : base(table)
        {
        }

        internal override void ProcessRoll(Dice roll)
        {
            BetOutcome outcome = new BetOutcome();

            if (Point.HasValue)
            {
                if (roll.Total == Point.Value)
                {
                    outcome.BetStatus = BetOutcome.Status.Lose;
                    outcome.Payout = 0;
                }
                else if (roll.Total == 7)
                {
                    outcome.BetStatus = BetOutcome.Status.Win;
                    outcome.Payout = 1 * Wager;
                }
                else
                {
                    outcome.BetStatus = BetOutcome.Status.NoAction;
                    outcome.Payout = 0;
                }
            }
            else
            {
                // Still in dont come box
                switch (roll.Total)
                {
                    case 7 or 11:
                        outcome.BetStatus = BetOutcome.Status.Lose;
                        outcome.Payout = 0;
                        break;
                    case 2 or 3:
                        outcome.BetStatus = BetOutcome.Status.Win;
                        outcome.Payout = 1 * Wager;
                        break;
                    case 12:
                        outcome.BetStatus = BetOutcome.Status.Push;
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
