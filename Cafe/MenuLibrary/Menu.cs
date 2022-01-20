using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuLibrary
{
    public class Menu
    {
        public Menu(){}

        public Menu (int number, string name, string description, string ingredients, double price)
        {
            Number = number;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }
    }
}