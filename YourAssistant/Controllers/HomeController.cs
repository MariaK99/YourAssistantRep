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

        public HomeController(IGame iGame)
        {
            _games = iGame;
        }
        
        [Authorize]
        public IActionResult Index()
        {
            return Content(User.Identity.Name);
        }
        /*
        public IActionResult Index()
        {
            return View();
        }
        */
        public IActionResult Rating()
        {
            return View();
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
