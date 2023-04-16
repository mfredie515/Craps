using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Bets.PropBets
{
    public class StraightUp : Prop
    {
        public enum StraightUpValue
        {
            Aces = 2,
            AceDeuce = 3,
            Yo = 11,
            Boxcars = 12
        }

        public StraightUp(Table table, StraightUpValue straightUpValue) : base(table)
        {
            Value = straightUpValue;
        }

        internal StraightUpValue Value { get; }

        internal override void ProcessRoll(Dice roll)
        {
            BetOutcome bo = new BetOutcome();
            bo.BetStatus = BetOutcome.Status.Lose; //Default handling
            bo.Payout = 0;

            if (roll.Total == (int)Value)
            {
                bo.BetStatus = BetOutcome.Status.Win;
                switch (Value)
                {
                    case StraightUpValue.Aces or StraightUpValue.Boxcars:
                        bo.Payout = 30 * Wager;
                        break;
                    case StraightUpValue.AceDeuce or StraightUpValue.Yo:
                        bo.Payout = 15 * Wager;
                        break;
                    default:
                        break;
                }
            }

            BetOutcome = bo;
        }
    }
}
