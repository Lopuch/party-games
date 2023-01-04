using AutoMapper;
using PartyGames.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PartyGames.Engine.Services
{
    public class LobbyService
    {
        

        private readonly IMapper _mapper;
        private readonly PartyGamesEngine _engine;
        private readonly PlayerService _playerService;

        private readonly PeriodicTimer _timer = new(TimeSpan.FromMilliseconds(1000));
        private readonly CancellationTokenSource _timerCancelSource;
        private readonly CancellationToken _timerCancel;

        public LobbyService(IMapper mapper, PartyGamesEngine engine, PlayerService playerService)
        {
            _mapper = mapper;
            _engine = engine;
            _playerService = playerService;

            _timerCancelSource = new CancellationTokenSource();
            _timerCancel = _timerCancelSource.Token;
        }

        public IGame CreateGame(string name)
        {
            var sanitizedName = SanitizeName(name);

            if(_engine.Games.Any(x=>x.Name == sanitizedName))
            {
                throw new ArgumentException("A game with this name already exists");
            }

            var game = new Game(sanitizedName);

            _engine.Games.Add(game);

            return game;
        }

        public List<IGame> GetGames()
        {
            RemoveFinishedGames();

            return _engine.Games;
        }

        public void JoinGame(Guid gameId, Guid playerId)
        {
            var game = GetGameById(gameId);
            var player = _playerService.GetPlayerById(playerId);

            game.AddPlayer(player);
            
        }

        public void StartGame(Guid gameId, Guid playerId)
        {
            var player = _playerService.GetPlayerById(playerId);
            var game = GetGameById(gameId);

            if(!game.GetPlayers().Any(x=> x == player))
            {
                throw new ArgumentException("Only joined players can start the game");
            }

            var state = game.GetGameState();

            if(state != Enums.GameEnum.GameStates.Prepare)
            {
                throw new InvalidOperationException("The game is not in the Prepare state");
            }

            game.Start();
        }

        public void SelectOption(Guid gameId, Guid playerId, int optionIndex)
        {
            var player = _playerService.GetPlayerById(playerId);
            var game = GetGameById(gameId);

            if(!game.GetPlayers().Any(x=>x == player))
            {
                throw new ArgumentException("Only joined players cas select an option");
            }

            var state = game.GetGameState();

            if (state != Enums.GameEnum.GameStates.Play)
            {
                throw new InvalidOperationException("The game is not in the Play state");
            }

            game.SelectOption(player, optionIndex);
        }

        public IGame GetGameById(Guid gameId)
        {
            var game = _engine.Games.FirstOrDefault(x => x.Id == gameId);

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

        private void RemoveFinishedGames()
        {
            var gamesToRemove = _engine.Games.Where(x => x.GetGameState() == Enums.GameEnum.GameStates.Finish).ToList();

            gamesToRemove.ForEach(x=>_engine.Games.Remove(x));
        }

        public void EnableGameType(Guid gameId, string gameType)
        {
            var game = GetGameById(gameId);
            game.EnableGameType(gameType);
        }

        public void DisableGameType(Guid gameId, string gameType)
        {
            var game = GetGameById(gameId);
            game.DisableGameType(gameType);
        }
    }
}
