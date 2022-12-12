using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUs.Model
{
    public class Recipe
    {
        static int CURRENT_ID = 0;
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Servings { get; set; }
        string _time;
        public string Time { get => "⏱️ " + _time;
            set => _time = value;
        }
        public Ingredient[] Ingredients { get; set; }
        public string[] Steps { get; set; }

        public Recipe(string image, string name, string description, int servings, string time, Ingredient[] ingredients, string[] steps)
        {
            Id = CURRENT_ID++;
            Image = image;
            Name = name;
            Description = description;
            Servings = servings;
            Time = time;
            Ingredients = ingredients;
            Steps = steps;
        }

        public Recipe(string name, string description, int servings, string time, Ingredient[] ingredients, string[] steps)
        {
            Id = CURRENT_ID++;
            Image = "default_recipe_img.jpg";
            Name = name;
            Description = description;
            Servings = servings;
            Time = time;
            Ingredients = ingredients;
            Steps = steps;
        }
    }
}
