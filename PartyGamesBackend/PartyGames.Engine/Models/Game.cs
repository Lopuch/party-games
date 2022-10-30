using PartyGames.Engine.Services.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyGames.Engine.Models
{
    public class Game : IGame
    {

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IGameService _gameService;


        private List<Player> Players { get; set; } = new List<Player>();

        private Round? CurrentRound { get; set; }


        public Game(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            _gameService = new GameSolveEquationService();
        }

        public List<Player> GetPlayers()
        {
            return Players.ToList();
        }

        public void AddPlayer(Player player)
        {
            if (Players.Contains(player))
            {
                throw new ArgumentException("The game already contains this player");
            }

            Players.Add(player);
        }

        public void NextRound()
        {
            CurrentRound = _gameService.GenerateNextRound();
        }
    }
}
