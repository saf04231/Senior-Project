using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace DADS.Models
{
    public class Game
    {
        public string DM { get; set; }
        public ICollection<User> Players { get; set; }
        public ICollection<string> Notes { get; set; }
        public ICollection<GameChar> Characters { get; set; }
        public ICollection<GameMap> Maps { get; set; }
    }

    public class GameChar
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Item> Inventory { get; set; }
        public ICollection<int> Stats { get; set; } //stats cooresponding to possition in code design
        public string Notes { get; set; }
    }

    public class GameMap
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Image Image { get; set; }
    }

    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public string Description { get; set; }
        public ICollection<string> Types { get; set; } //i.e. peircing, melee 
    }
}