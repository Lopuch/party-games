namespace PartyGames.API.DTOs
{
    public class RoundTitleDto
    {
        public string Text { get; set; }

        public RoundTitleDto(string text)
        {
            Text = text;
        }
    }
}
