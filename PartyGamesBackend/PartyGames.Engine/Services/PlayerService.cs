using AutoMapper;
using PartyGames.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyGames.Engine.Services
{
    public class PlayerService
    {
        private List<Player> Players { get; set; } = new List<Player>();

        private readonly IMapper _mapper;

        public PlayerService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Player GetPlayerById(Guid playerId)
        {
            var player = Players.FirstOrDefault(x => x.Id == playerId);

            if(player == null)
            {
                throw new KeyNotFoundException("Player with this id was not found");
            }

            return player;
        }

        public Player Login(string name)
        {
            var nameSanitized = SanitizeName(name);

            if(Players.Any(x => x.Name == nameSanitized))
            {
                throw new ArgumentException($"Player with name '{name}' already exists");
            }

            var player = new Player(Guid.NewGuid(), nameSanitized);
            Players.Add(player);

            return player;
        }

        public Player ReLogin(string name, Guid playerId)
        {
            if(playerId == Guid.Empty)
            {
                throw new ArgumentException("PlayerId should not be an emplty guid");
            }

            var player = Players.FirstOrDefault(x => x.Id == playerId);

            if(player == null)
            {
                player = new Player(playerId, name);
                Players.Add(player);
            }

            player.Name = name;

            return player;
        }

        private string SanitizeName(string name)
        {
            return name.Trim();
        }
    }
}
