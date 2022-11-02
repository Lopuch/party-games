namespace PartyGames.API.DTOs.Player
{
    public class Player_ReloginDto
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

        public Player_ReloginDto(string name, Guid id)
        {
            Name = name;
            Id = id;
        }
    }
}
