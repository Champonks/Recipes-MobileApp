using api.Model;

namespace api.DTO
{
    public class RecipeReadDTO
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Servings { get; set; }
        public CookingSeason RecipeSeason { get; set; }
        public string Time { get; set; }
        public List<IngredientReadDTO> Ingredients { get; set; }
        public List<StepReadDTO> Steps { get; set; }
        public UserReadDTO Author { get; set; }
    }
}