namespace PartyGames.API.DTOs
{
    public class RoundOptionDto
    {
        public string Text { get; set; }
        public bool? PublicIsCorrect { get; set; }

        public RoundOptionDto(string text)
        {
            Text = text;
        }
    }
}
