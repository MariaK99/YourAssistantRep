using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YourAssistant.Models
{
    public class LevelGameRating
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public GameLevel Level { get; set; }
        public User User { get; set; }
        public int Points { get; set; }

    }
}
