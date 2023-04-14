using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core
{
    public class Table
    {
        private List<Player> players;

        public Table()
        {
            players = new List<Player>();
        }

        public bool PointEstablished { get { return Point.HasValue; } }
        public int? Point { get; internal set; }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
    }
}
