using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourAssistant.Interfaces;
using YourAssistant.Models;
using YourAssistant.ViewModels;

namespace YourAssistant.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGame _games;

        private AssistantContext db;

        public HomeController(IGame iGame,AssistantContext context)
        {
            _games = iGame;
            this.db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Rating()
        {
            List<LevelGameRating> gameRatings = db.LevelRating.OrderByDescending(lr => lr.Points).ToList();

            foreach(LevelGameRating rating in gameRatings)
            {
                rating.Level = db.Levels.FirstOrDefault(l => l.Id == db.LevelRating.FirstOrDefault(lr => lr.Id == rating.Id).Level.Id);
                rating.User = db.Users.FirstOrDefault(u => u.Id == db.LevelRating.FirstOrDefault(lr => lr.Id == rating.Id).User.Id);
                rating.Game = db.Games.FirstOrDefault(g => g.Id == db.LevelRating.FirstOrDefault(lr => lr.Id == rating.Id).Game.Id);
            }
            return View(gameRatings);
        }

        //[Route("Home/Games")]
        public ViewResult Games()
        {
            IEnumerable<Game> games = _games.AllGames.OrderBy(i => i.Id);

            var gamesView = new GameListView
            {
                AllGames = games
            };
            ViewBag.Title = "Games";

            return View(gamesView);
        }

        public IActionResult Annotation()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
