using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourAssistant.Models;
using YourAssistant.Models.Games;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YourAssistant.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private static List<UserNumber> numbers;

        private static string _correct;

        private AssistantContext db;

        public GameController(AssistantContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult KingNumbers()
        {
            return View();
        }

        [Route("Game/KingNumbers/{numbersSystem:int}/{numbersCount:int}")]
        public async Task<IActionResult> KingNumbers(int numbersSystem, int numbersCount)
        {
            if (numbersSystem != 0 && numbersCount != 0)
            {
                KingNumber number = new KingNumber
                {
                    NumeralSystem = numbersSystem,
                    NumberCount = numbersCount
                };
                number.GenerateNewNumber();
                _correct = number.Line;
                return RedirectToAction("KingNumbersScene", "Game");
            }
            else                      
                return View();
        }

        [HttpGet]
        public IActionResult KingNumbersScene()
        {
            numbers = new List<UserNumber>();
            return View(numbers);
        }
        
        [HttpPost]
        public async Task<IActionResult> KingNumbersScene(UserNumber number)
        {
            for (int i = 0; i < number.UserLine.Length; i++)
            {
                for (int j = 0; j < _correct.Length; j++)
                {
                    if (number.UserLine[i] == _correct[j])
                    {
                        number.queens++;
                        if (i == j)
                            number.kings++;
                        break;
                    }
                }
            }
            numbers.Add(number);
            if (number.kings == number.UserLine.Length)
            {
                Game game = db.Games.FirstOrDefault(g => g.Id == 1);
                GameLevel level;
                YourAssistant.Models.User user = db.Users.FirstOrDefault(u => u.Name == User.Identity.Name);
                if (number.kings==3)
                {
                    level = db.Levels.FirstOrDefault(l => l.Name == "Легко");
                }
                else if (number.kings == 4)
                {
                    level = db.Levels.FirstOrDefault(l => l.Name == "Нормально");
                }
                else
                {
                    level = db.Levels.FirstOrDefault(l => l.Name == "Сложно");
                }
                LevelGameRating rating = new LevelGameRating
                {
                    Game = game,
                    Level = level,
                    User = user,
                    Points = (int)(100 / Math.Sqrt(numbers.Count) * level.PointRate)
                };
                int k = 0;

                foreach(LevelGameRating dbRating in db.LevelRating)
                {
                    dbRating.User = db.Users.FirstOrDefault(u => u.Id == db.LevelRating.FirstOrDefault(lr => lr.Id == dbRating.Id).User.Id);
                    if (dbRating.Game.Id==game.Id && dbRating.Level.Id==level.Id && dbRating.User.Name == user.Name)
                    {
                        if (dbRating.Points < rating.Points)
                            dbRating.Points = rating.Points;
                        k = -1;
                        break;
                    }
                }
                if (k == 0)
                    db.LevelRating.Add(rating);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(numbers);
            }
        }
        
    }
}
