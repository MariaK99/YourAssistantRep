using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourAssistant.Models
{
    public class GameRating
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public User User { get; set; }
        public int Points { get; set; }
    }
}
