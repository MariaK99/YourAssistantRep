using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourAssistant.Models
{
    public class GameLevel
    {
        public int Id { get; set; }
        public Game game {get;set;}
        public string Name { get; set; }
        public float PointRate { get; set; }
    }
}
