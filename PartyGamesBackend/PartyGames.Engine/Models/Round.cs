using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyGames.Engine.Models
{
    public class Round
    {
        public RoundTitle Title { get; set; }
        public List<RoundOption> Options { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Round(RoundTitle title, List<RoundOption> options, DateTime startTime, DateTime endTime)
        {
            Title = title;
            Options = options;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
