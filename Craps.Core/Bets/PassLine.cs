using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Bets
{
    /// <summary>
    /// The Pass Line bet, on the comeout roll it wins on a 7 or 11 and loses on a 2, 3, or 12.
    /// After the point is established it wins on the point being hit and loses on a 7.
    /// This pays out 1:1 and is a contract bet
    /// </summary>
    public class PassLine : Bet, ICanHaveOdds
    {
        public PassLine(Table table) : base(table)
        {
        }

        public Table UnderlyingTable { get { return Game; } }
        public BetOutcome UnderlyingOutcome { get { return BetOutcome; } }

        internal override bool CanPlaceBet()
        {
            if (Game.PointEstablished)
                return false;
            return true;
        }

        internal override void ProcessRoll(Dice roll)
        {
            BetOutcome outcome = new BetOutcome();

            if (Game.PointEstablished)
            {
                if (roll.Total == 7)
                {
                    outcome.BetStatus = BetOutcome.Status.Lose;
                    outcome.Payout = 0;
                }
                else if (roll.Total == Game.Point.Value)
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
                        break;
                }
            }

            BetOutcome = outcome;
        }
    }
}
