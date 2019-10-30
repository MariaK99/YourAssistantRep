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
                        Name = "Быки и коровы",
                        Image = "CowBulls.png",
                        Description = "Быки и коровы это очень интересная игра"
                    },
                    new Game
                    {
                        Name = "Камушки",
                        Image = "Stones.png",
                        Description = "Камушки это тоже очень интересная игра"
                    },
                    new Game
                    {
                        Name = "Матрица",
                        Image = "Matrix.png",
                        Description = "Это впрям вообще интересная игра"
                    });
                context.SaveChanges();
            }
        }
    }
}
