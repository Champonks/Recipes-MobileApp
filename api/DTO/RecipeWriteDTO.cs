using api.Model;

namespace api.DTO
{
    public class RecipeWriteDTO
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Servings { get; set; }
        public CookingSeason RecipeSeason { get; set; }
        public string Time { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }
    }
}