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
        public List<PlayerDto> Players { get; set; }
        public RoundDto? Round { get; set; }
        public List<ResultDto> Results { get; set; }
        public List<ResultDto> LastResults { get; set; }


        public GameDto(string name, Guid id, GameStates gameState, List<PlayerDto> players, RoundDto? round, List<ResultDto> results, List<ResultDto> lastResults)
        {
            Name = name;
            Id = id;
            GameState = gameState;
            Players = players;
            Round = round;
            Results = results;
            LastResults = lastResults;
        }
    }
}
