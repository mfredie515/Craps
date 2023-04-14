using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core
{
    public abstract class Bet
    {
        protected internal Table Game;

        protected Bet(Table table)
        {
            Game = table;
        }
        
        public int Wager { get; set; }
        public BetOutcome BetOutcome { get; internal set; }
        internal abstract void ProcessRoll(Dice roll);
        internal abstract bool CanPlaceBet();
    }
}
