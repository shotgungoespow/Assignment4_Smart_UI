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
            new Ingredient() { Name = "Milk", Amount = 5, Weight = 2.4, Liquid = true , Image = "milk.jpg" },
            new Ingredient() { Name = "Egg", Amount = 2, Weight = 1.1, Liquid = false , Image = "eggs.jpg" },
            new Ingredient() { Name = "Bread", Amount = 7, Weight = 3.3, Liquid = false , Image = "bread.jpg" }


        };
        public static List<Ingredient> GetIngredients()
        {
            return ingredients;
        }
        public static List<User> users = new List<User>()
        {
            new User() {  Name = "Yair Gueta", Email = "yair.gueta.09@gmail.com", Password = "sheleg2009", FName = "Gueta", PName = "Yair" },
            new User() {  Name = "Mody GlimFeather", Email = "Mody.Glimfeather@gmail.com", Password = "Rock123", FName = "Glimfeather", PName = "Mody" }
        };
    }
}