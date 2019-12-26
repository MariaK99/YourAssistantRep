using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YourAssistant.Models.Games;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YourAssistant.Controllers
{
    public class GameController : Controller
    {
        private static List<UserNumber> numbers;

        private static string _correct;

        public GameController()
        {
        }

        [HttpGet]
        public IActionResult KingNumbers()
        {
            return View();
        }

        //[HttpPost]
        [Route("Game/KingNumbers/{numbersSystem:int}/{numbersCount:int}")]
        public async Task<IActionResult> KingNumbers(int numbersSystem,int numbersCount)
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
        public IActionResult KingNumbersScene(UserNumber number)
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
            if (number.kings == number.UserLine.Length)
                return RedirectToAction("Index", "Home");
            else
            {
                numbers.Add(number);
                return View(numbers);
            }
        }
        
    }
}
