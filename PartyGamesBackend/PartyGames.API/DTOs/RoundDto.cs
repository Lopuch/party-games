using PartyGames.Engine.Models;

namespace PartyGames.API.DTOs
{
    public class RoundDto
    {
        public RoundTitleDto Title { get; set; }
        public List<RoundOptionDto> Options { get; set; }

        public RoundDto(RoundTitleDto title, List<RoundOptionDto> options)
        {
            Title = title;
            Options = options;
        }
    }
}
