using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core
{
    public class Player
    {
        public string PlayerName { get; internal set; }
        public Color PlayerColor { get; internal set; }        
        public int Bankroll { get; internal set; }

        public Dice Shoot()
        {
            return Dice.Roll();
        }
    }
}
