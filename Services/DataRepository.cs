using Assignment4_Smart_UI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4_Smart_UI.Services
{
    internal class DataRepository
    {
        public static List<Ingredient> ingredients = new List<Ingredient>()
        {
            new Ingredient() { name = "Milk", price = 5, image = "milk.jpg" },
            new Ingredient() { name = "Egg", price = 2, image = "egg.jpg" },
            new Ingredient() { name = "Bread", price = 7, image = "bread.jpg" }


        };
        public static List<Ingredient> GetIngredients()
        {
            return ingredients;
        }
    }
}