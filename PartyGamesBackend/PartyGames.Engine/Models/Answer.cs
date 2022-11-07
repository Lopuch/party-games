using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyGames.Engine.Models
{
    internal class Answer
    {
        public Player Player { get; set; }
        public RoundOption Option { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime Time { get; set; }

        public Answer(Player player, bool isCorrect, RoundOption option, DateTime time)
        {
            Player = player;
            Option = option;
            IsCorrect = isCorrect;
            Time = time;
        }
    }
}
