using System;

namespace game_catalog.Models
{
    public class Game
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string producer { get; set; }
        public double price { get; set; }
    }
}
