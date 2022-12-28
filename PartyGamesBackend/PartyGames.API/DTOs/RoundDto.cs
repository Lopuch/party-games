using PartyGames.Engine.Models;

namespace PartyGames.API.DTOs
{
    public class RoundDto
    {
        public RoundTitleDto Title { get; set; }
        public List<RoundOptionDto> Options { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public RoundDto(RoundTitleDto title, List<RoundOptionDto> options, DateTime startTime, DateTime endTime)
        {
            Title = title;
            Options = options;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
