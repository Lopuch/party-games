namespace PartyGames.API.DTOs.Game
{
    public class Game_DisableGameTypeDto
    {
        public Guid GameId { get; set; }
        public required string GameType { get; set; }
    }
}
