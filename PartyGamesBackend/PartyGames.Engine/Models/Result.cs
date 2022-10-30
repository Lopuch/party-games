using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyGames.Engine.Models
{
    public class Result
    {
        public Player Player { get; set; }
        public int Points { get; set; }
        public Result(Player player, int points)
        {
            Player = player;
            Points = points;
        }
    }
}
