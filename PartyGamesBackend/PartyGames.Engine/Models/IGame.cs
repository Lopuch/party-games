using PartyGames.Engine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyGames.Engine.Models
{
    public interface IGame
    {
        string Name { get; }
        Guid Id { get; }
        List<Player> GetPlayers();
        void AddPlayer(Player player);
        GameEnum.GameStates GetGameState();
        void Start();
        void SelectOption(Player player, int optionIndex);
        Round? GetRound();
        List<Result> GetResults();
        List<Result> GetLastResults();
        string GetGameType();
    }
}
