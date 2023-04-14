using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Bets
{
    /// <summary>
    /// The Field bet, a single roll bet that wins 1:1 on 3, 4, 9, 10, or 11 and wins 2:1 on 2 or 12. 
    /// Each other number is a loss.
    /// </summary>
    public class Field : Bet
    {
        public Field(Table table) : base(table) { }

        internal override bool CanPlaceBet()
        {
            return true;
        }

        internal override void ProcessRoll(Dice roll)
        {
            BetOutcome outcome = new BetOutcome();
            switch (roll.Total)
            {
                case 2 or 12: // Win 2:1
                    outcome.Payout = 2 * Wager;
                    outcome.BetStatus = BetOutcome.Status.Win;
                    break;
                case 3 or 4 or 9 or 10 or 11: // Win 1:1
                    outcome.Payout = 1 * Wager;
                    outcome.BetStatus = BetOutcome.Status.Win;
                    break;
                default: // Lose
                    outcome.Payout = 0;
                    outcome.BetStatus = BetOutcome.Status.Lose;
                    break;
            }

            BetOutcome = outcome;
        }
    }
}
