using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyGames.Engine.Models
{
    public class RoundOption
    {
        public override string ToString()
        {
            return $"{IsCorrect} {Text}";
        }

        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public bool? PublicIsCorrect { get; set; }

        public RoundOption(string text, bool isCorrect)
        {
            Text = text;
            IsCorrect = isCorrect;
        }
    }
}
