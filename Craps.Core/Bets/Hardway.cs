using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Bets
{
    public class Hardway : Bet
    {
        public enum HardwaysValue
        {
            Hard4 = 4,
            Hard6 = 6,
            Hard8 = 8,
            Hard10 = 10
        }
        public Hardway(Table table, HardwaysValue hardwaysValue) : base(table)
        {
            Value = hardwaysValue;
        }

        internal HardwaysValue Value { get; private set; }

        internal override bool CanPlaceBet()
        {
            //Obviously this needs to be more complex with on-off and such
            if (Game.PointEstablished)
                return true;
            return false;
        }

        internal override void ProcessRoll(Dice roll)
        {
            BetOutcome outcome = new BetOutcome();
            outcome.BetStatus = BetOutcome.Status.NoAction; //Default handling
            outcome.Payout = 0;

            //Set all easy & hard numbers to a loss
            //Set it to win in the switch if correct
            if (roll.Total == (int)Value || roll.Total == 7)
                outcome.BetStatus = BetOutcome.Status.Lose;

            switch (Value)
            {
                case HardwaysValue.Hard4:
                    if (roll.Die1 == 2 && roll.Die2 == 2)
                    {
                        outcome.BetStatus = BetOutcome.Status.Win;
                        outcome.Payout = 7;
                    }
                    break;
                case HardwaysValue.Hard6:
                    if (roll.Die1 == 3 && roll.Die2 == 3)
                    {
                        outcome.BetStatus = BetOutcome.Status.Win;
                        outcome.Payout = 9;
                    }
                    break;
                case HardwaysValue.Hard8:
                    if (roll.Die1 == 4 && roll.Die2 == 4)
                    {
                        outcome.BetStatus = BetOutcome.Status.Win;
                        outcome.Payout = 9;
                    }
                    break;
                case HardwaysValue.Hard10:
                    if (roll.Die1 == 5 && roll.Die2 == 5)
                    {
                        outcome.BetStatus = BetOutcome.Status.Win;
                        outcome.Payout = 7;
                    }
                    break;
                default:
                    break;
            }

            BetOutcome = outcome;
        }
    }
}
