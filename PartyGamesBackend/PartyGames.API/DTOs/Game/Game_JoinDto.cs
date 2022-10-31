namespace PartyGames.API.DTOs.Game
{
    public class Game_JoinDto
    {
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }

        public Game_JoinDto(Guid gameId, Guid playerId)
        {
            GameId = gameId;
            PlayerId = playerId;
        }
    }
}
