using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Bets.PropBets
{
    public class AnyCraps : Prop
    {
        public AnyCraps(Table table) : base(table)
        {
        }

        internal override void ProcessRoll(Dice roll)
        {
            BetOutcome bo = new BetOutcome();

            switch (roll.Total)
            {
                case 2 or 3 or 12:
                    bo.BetStatus = BetOutcome.Status.Win;
                    bo.Payout = 7 * Wager;
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
