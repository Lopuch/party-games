using AutoMapper;
using PartyGames.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyGames.Engine.Services
{
    public class LobbyService
    {
        private List<IGame> Games { get; set; } = new List<IGame>();

        private readonly IMapper _mapper;
        private readonly PlayerService _playerService;

        public LobbyService(IMapper mapper, PlayerService playerService)
        {
            _mapper = mapper;
            _playerService = playerService;
        }

        public IGame CreateGame(string name)
        {
            var sanitizedName = SanitizeName(name);

            if(Games.Any(x=>x.Name == sanitizedName))
            {
                throw new ArgumentException("A game with this name already exists");
            }

            var game = new Game(sanitizedName);

            return game;
        }

        public List<IGame> GetGames()
        {
            return Games;
        }

        public void JoinGame(Guid gameId, Guid playerId)
        {
            var game = GetGameById(gameId);
            var player = _playerService.GetPlayerById(playerId);

            game.AddPlayer(player);
            
        }

        public IGame GetGameById(Guid gameId)
        {
            var game = Games.FirstOrDefault(x => x.Id == gameId);

            if(game == null)
            {
                throw new KeyNotFoundException("Game with this id was not found");
            }

            return game;
        }

        private string SanitizeName(string name)
        {
            return name.Trim();
        }
    }
}
