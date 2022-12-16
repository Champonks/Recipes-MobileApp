using Microsoft.AspNetCore.Mvc;
using ASPNET.Model;

namespace ASPNET.Controllers
{
    [ApiController]
    [Route("api/recipe")]
    public class RecipeController : ControllerBase
    {
        List<Recipe> Recipes = new();
        public RecipeController() {
            List<Ingredient> ingredients = new()
            {
                new Ingredient() { Name = "Tomato", Quantity = "200g" },
                new Ingredient() { Name = "Pasta", Quantity = "500g" },
                new Ingredient() { Name = "Cheese", Quantity = "200g" },
                new Ingredient() { Name = "Cream", Quantity = "200ml" },
                new Ingredient() { Name = "Butter", Quantity = "100g" },
                new Ingredient() { Name = "Salad", Quantity = "1" },
                new Ingredient() { Name = "Carrots", Quantity = "5" }
            };

            List<string> steps = new()
            {
                "Put Bread in the oven",
                "Put beef between the bread",
                "Add any toppings"
            };

            Recipe r1 = new("burger.jpg", "Burger", "Miam miam", 4, CookingSeason.All, "25min", ingredients, steps);
            Recipe r2 = new("pates.jpg", "Pasta", "Italia", 2, CookingSeason.All, "30min", ingredients, steps);
            Recipe r3 = new("pizza.jpg", "Pizza", "MAMAMIA", 6, CookingSeason.All, "45min", ingredients, steps);

            Recipes.Add(r1);
            Recipes.Add(r2);
            Recipes.Add(r3);
        }
        public ActionResult GetAllRecipes()
        {
            return Ok(Recipes);
        }
    }
}