namespace PartyGames.API.DTOs.Game
{
    public class Game_SelectOptionDto
    {
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }
        public int OptionIndex { get; set; }

        public Game_SelectOptionDto(Guid gameId, Guid playerId, int optionIndex)
        {
            GameId = gameId;
            PlayerId = playerId;
            OptionIndex = optionIndex;
        }
    }
}
