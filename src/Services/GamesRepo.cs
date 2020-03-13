using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using thegame.Models;

namespace thegame.Services
{
    public static class GamesRepo
    {
        public static readonly Dictionary<Guid, GameBoard> Games = new Dictionary<Guid, GameBoard>();
    }
}