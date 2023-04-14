﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Bets
{
    public interface ICanHaveOdds
    {
        Table UnderlyingTable { get; }
        BetOutcome UnderlyingOutcome { get; }
    }
}
