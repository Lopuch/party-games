using PartyGames.API.DTOs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PartyGames.Engine.Enums.GameEnum;

namespace PartyGames.API.DTOs
{
    public class GameDto
    {
        public string? Name { get; set; }
        public Guid Id { get; set; }
        public GameStates GameState { get; set; }
        public required List<PlayerDto> Players { get; set; }
        public RoundDto? Round { get; set; }
        //public List<ResultDto> Results { get; set; }
        public required List<ResultDto> LastResults { get; set; }
        public required string Type { get; set; }
        public required List<string> AllowedGameTypes { get; set; }


        
    }
}
