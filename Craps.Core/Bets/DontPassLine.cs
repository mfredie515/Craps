using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Bets
{
    /// <summary>
    /// The Don't Pass Line bet, basically an inverted Pass Line bet.
    /// On the comeout roll it wins on a 2 or 3, and loses on a 7 or 11 (Rolling a 12 is a push.)
    /// Once the point is established, it wins on a 7 and loses if the point is hit.
    /// This pays out 1:1
    /// </summary>
    public class DontPassLine : PassLine
    {
        public DontPassLine(Table table) : base(table)
        {
        }

        internal override void ProcessRoll(Dice roll)
        {
            BetOutcome outcome = new BetOutcome();

            if (Game.PointEstablished)
            {
                if (roll.Total == 7)
                {
                    outcome.BetStatus = BetOutcome.Status.Win;
                    outcome.Payout = 1 * Wager;
                }
                else if (roll.Total == Game.Point.Value)
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
                        break;
                }
            }

            BetOutcome = outcome;
        }
    }
}
