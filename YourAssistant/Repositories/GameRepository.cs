using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourAssistant.Interfaces;
using YourAssistant.Models;

namespace YourAssistant.Repositories
{
    public class GameRepository : IGame
    {
        private readonly AssistantContext context;

        public GameRepository(AssistantContext context)
        {
            this.context = context;
        }

        public IEnumerable<Game> AllGames => context.Games;

        public Game GetGameById(int GameId) => context.Games.FirstOrDefault(g => g.Id == GameId);
    }
}
