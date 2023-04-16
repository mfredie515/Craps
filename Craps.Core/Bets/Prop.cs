using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Bets
{
    public abstract class Prop : Bet, ISingleRollBet
    {
        protected Prop(Table table) : base(table)
        {
        }

        internal override bool CanPlaceBet()
        {
            return true;
        }
    }
}
