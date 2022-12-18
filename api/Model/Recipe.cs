using System.ComponentModel.DataAnnotations.Schema;

namespace api.Model
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
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Servings { get; set; }
        public CookingSeason RecipeSeason { get; set; }
        public string Time { get; set; }
        
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }

        public string UserLogin { get; set; }
        [ForeignKey("UserLogin")]
        public User Author { get; set; }
    }
}