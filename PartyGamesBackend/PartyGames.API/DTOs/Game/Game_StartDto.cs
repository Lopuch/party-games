namespace PartyGames.API.DTOs.Game
{
    public class Game_StartDto
    {
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }

        public Game_StartDto(Guid gameId, Guid playerId)
        {
            GameId = gameId;
            PlayerId = playerId;
        }
    }
}
