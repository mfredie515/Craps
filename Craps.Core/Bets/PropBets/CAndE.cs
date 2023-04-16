using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Bets.PropBets
{
    public class CAndE : Prop
    {
        public CAndE(Table table) : base(table)
        {
        }

        internal override void ProcessRoll(Dice roll)
        {
            BetOutcome bo = new BetOutcome();

            switch (roll.Total)
            {
                case 2 or 3 or 12:
                    bo.BetStatus = BetOutcome.Status.Win;
                    /** Payout
                     *  7 : 1
                     *  (7 * 0.5x) - 0.5x
                     *  (3.5 - 0.5)x
                     */
                    bo.Payout = (3 * Wager);
                    break;
                case 11:
                    bo.BetStatus = BetOutcome.Status.Win;
                    /** Payout
                     *  15 : 1
                     *  (15 * 0.5x) - 0.5x
                     *  (7.5 - 0.5)x
                     */
                    bo.Payout = (7 * Wager);
                    break;
                default:
                    bo.BetStatus = BetOutcome.Status.Lose;
                    bo.Payout = 0;
                    break;
            }

            BetOutcome = bo;
        }
    }
}
