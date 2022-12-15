using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUs.Model
{
    public enum CookingSeason
    {
        Winter = 1,
        Spring,
        Summer,
        Autumn,
        All = 0
    }
    public class Recipe
    {
        static int CURRENT_ID = 0;
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Servings { get; set; }
        public CookingSeason RecipeSeason { get; set; }
        string _time;
        public string Time { get => "⏱️ " + _time;
            set => _time = value;
        }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public Recipe(string image, string name, string description, double servings, CookingSeason recipeSeason, string time, List<Ingredient> ingredients, List<string> steps)
        {
            Id = CURRENT_ID++;
            Image = image;
            Name = name;
            Description = description;
            Servings = servings;
            RecipeSeason = recipeSeason;
            Time = time;
            Ingredients = ingredients;
            Steps = steps;
        }

        public Recipe(string name, string description, double servings, CookingSeason recipeSeason, string time, List<Ingredient> ingredients, List<string> steps)
        {
            Id = CURRENT_ID++;
            Image = "default_recipe_img.jpg";
            Name = name;
            Description = description;
            Servings = servings;
            RecipeSeason = recipeSeason;
            Time = time;
            Ingredients = ingredients;
            Steps = steps;
        }
    }
}
