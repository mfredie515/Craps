using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Bets
{
    public class Odds<T> : Bet where T : ICanHaveOdds
    {
        private T mUnderlying;

        internal Odds(T underlying) : base(underlying.UnderlyingTable)
        {
            mUnderlying = underlying;
        }

        internal override bool CanPlaceBet()
        {
            switch (mUnderlying)
            {
                case DontPassLine or PassLine:
                    return Game.PointEstablished;
                case DontCome dc:
                    return dc.Point.HasValue;
                case Come c:
                    return c.Point.HasValue;
                default:
                    return false;
            }
        }

        internal override void ProcessRoll(Dice roll)
        {
            BetOutcome outcome = new BetOutcome();
            outcome.BetStatus = mUnderlying.UnderlyingOutcome.BetStatus;
            if (mUnderlying.UnderlyingOutcome.BetStatus == BetOutcome.Status.Win)
            {
                switch (mUnderlying)
                {
                    case DontPassLine:
                        switch (Game.Point)
                        {
                            case 4 or 10:
                                outcome.Payout = (0.5 * Wager).FuzzyFloor(); //1:2
                                break;
                            case 5 or 9:
                                outcome.Payout = (0.6666 * Wager).FuzzyFloor(); //2:3
                                break;
                            case 6 or 8:
                                outcome.Payout = (0.8333 * Wager).FuzzyFloor(); //5:6
                                break;
                            default:
                                outcome.Payout = mUnderlying.UnderlyingOutcome.Payout; //No action/push
                                break;
                        }
                        break;
                    case DontCome dc:
                        switch (dc.Point)
                        {
                            case 4 or 10:
                                outcome.Payout = (0.5 * Wager).FuzzyFloor(); //1:2
                                break;
                            case 5 or 9:
                                outcome.Payout = (0.6666 * Wager).FuzzyFloor(); //2:3
                                break;
                            case 6 or 8:
                                outcome.Payout = (0.8333 * Wager).FuzzyFloor(); //5:6
                                break;
                            default:
                                outcome.Payout = mUnderlying.UnderlyingOutcome.Payout; //No action/push
                                break;
                        }
                        break;
                    case PassLine or Come:
                        switch (roll.Total)
                        {
                            case 4 or 10:
                                outcome.Payout = 2 * Wager; //2:1
                                break;
                            case 5 or 9:
                                outcome.Payout = (1.5 * Wager).FuzzyFloor(); //3:2
                                break;
                            case 6 or 8:
                                outcome.Payout = (1.2 * Wager).FuzzyFloor(); //6:5
                                break;
                            default:
                                outcome.Payout = mUnderlying.UnderlyingOutcome.Payout; //No action/push
                                break;
                        }
                        break;
                    default:
                        outcome.Payout = 0;
                        break;
                }
            }

            BetOutcome = outcome;
        }
    }
}
