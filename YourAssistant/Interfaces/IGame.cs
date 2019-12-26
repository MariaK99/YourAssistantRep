using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourAssistant.Models;

namespace YourAssistant.Interfaces
{
    public interface IGame
    {
        IEnumerable<Game> AllGames { get; }

        Game GetGameById(int GameId);
    }
}
