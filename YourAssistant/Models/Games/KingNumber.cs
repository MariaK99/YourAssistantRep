using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YourAssistant.Models.Games
{
    public class KingNumber
    {

        public readonly string start = "0123456789abcdefghij";

        public string Line { get; set; } = "";

        [Required]
        [Range(1, 20, ErrorMessage = "Введите число в диапазоне от 1 до 20")]
        [Display(Name = "Количество разрядов")]
        public int NumberCount { get; set; }


        [Required]
        [Range(1, 20, ErrorMessage = "Введите число в диапазоне от 1 до 20")]
        [Display(Name = "Размерность системы счисления")]
        public int NumeralSystem { get; set; }

        public void GenerateNewNumber()
        {
            Random random = new Random();
            List<char> letters = new List<char>();

            for (int i = 0; i < NumeralSystem; i++)
                letters.Add(start[i]);

            while (Line.Length < NumberCount)
            {
                char symbol = letters[random.Next(letters.Count - 1)];
                Line += symbol;
                letters.Remove(symbol);
            }
        }
    }
}
