namespace PartyGames.API.DTOs.Game
{
    public class Game_CreateDto
    {
        public string Name { get; set; }

        public Game_CreateDto(string name)
        {
            Name = name;
        }
    }
}
