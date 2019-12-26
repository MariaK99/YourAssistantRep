using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourAssistant.Models;

namespace YourAssistant.ViewModels
{
    public class GameListView
    {
        public IEnumerable<Game> AllGames { get; set; }

        //public string characterSeason { get; set; }
    }
}
