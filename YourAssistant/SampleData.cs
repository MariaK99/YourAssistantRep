using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourAssistant.Models;

namespace YourAssistant
{
    public class SampleData
    {
        public static void Initialize(AssistantContext context)
        {
            if(!context.Games.Any())
            {
                context.Games.AddRange(
                    new Game
                    {
                        Name = "KingNumbers",
                        Image = "/Images/Games/KingNumbers.jpg",
                        Description = "Королевские числа — логическая игра, в ходе которой за несколько попыток один из игроков должен определить, какое число задумал другой игрок..."
                    },
                    new Game
                    {
                        Name = "Стратег",
                        Image = "/Images/Games/Strateg.png",
                        Description = "Сратег - игра, в которой предлагается, построив выйгрышную стратегию, обыграть компьютер, который настроен только на победу..."
                    },
                    new Game
                    {
                        Name = "Переводчик",
                        Image = "/Images/Games/Translator.png",
                        Description = "Переводчик - игра, в которой требуется за определенное время перевести число из одной системы счисления в другую..."
                    });
                context.SaveChanges();
            }
        }
    }
}
