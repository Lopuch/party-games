namespace PartyGames.API.DTOs
{
    public class ResultDto
    {
        public string PlayerName { get; set; }
        public int? Points { get; set; }
        public ResultDto(string playerName, int? points)
        {
            PlayerName = playerName;
            Points = points;
        }
    }
}
