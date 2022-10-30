﻿using System;
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
    }
}