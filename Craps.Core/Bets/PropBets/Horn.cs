using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Bets.PropBets
{
    public class Horn : Prop
    {
        public Horn(Table table) : base(table)
        {
        }

        internal override bool CanPlaceBet()
        {
            return (Wager % 4 == 0);
        }

        internal override void ProcessRoll(Dice roll)
        {
            BetOutcome bo = new BetOutcome();

            switch (roll.Total)
            {
                case 2 or 12:
                    bo.BetStatus = BetOutcome.Status.Win;
                    /** Payout
                     *  30 : 1
                     *  (30 * 0.25x) - 0.75x
                     *  (30 - 3) * 0.25x
                     */
                    bo.Payout = 27 * (Wager / 4); //Wager must be multiple of 4
                    break;
                case 3 or 11:
                    bo.BetStatus = BetOutcome.Status.Win;
                    /** Payout
                     *  15 : 1
                     *  (15 * 0.25x) - 0.75x
                     *  (15 - 3) * 0.25x
                     *  12 * 0.25x
                     */
                    bo.Payout = 3 * Wager;
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
