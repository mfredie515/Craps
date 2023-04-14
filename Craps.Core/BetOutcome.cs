using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core
{
    public class BetOutcome
    {
        public enum Status
        {
            Win,
            Lose,
            NoAction,
            Push
        }
        public Status BetStatus { get; internal set; }
        public int Payout { get; internal set; }
    }
}
