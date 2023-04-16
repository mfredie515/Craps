using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Bets.PropBets
{
    public class AnySeven : Prop
    {
        public AnySeven(Table table) : base(table)
        {
        }

        internal override void ProcessRoll(Dice roll)
        {
            BetOutcome bo = new BetOutcome();

            switch (roll.Total)
            {
                case 7:
                    bo.BetStatus = BetOutcome.Status.Win;
                    bo.Payout = 4 * Wager;
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
