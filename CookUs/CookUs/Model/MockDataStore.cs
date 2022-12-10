using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUs.Model
{
    public class MockDataStore : IDataStore
    {
        public List<Recipe> Recipes { get; set; }

        public MockDataStore()
        {
            Recipes = new List<Recipe>();
            //add some mock data
            List<Ingredient> ingredients = new();
            ingredients.Add(new Ingredient() { Name = "Tomato", Quantity = "200g" });
            ingredients.Add(new Ingredient() { Name = "Pasta", Quantity = "500g" });
            ingredients.Add(new Ingredient() { Name = "Cheese", Quantity = "200g" });
            ingredients.Add(new Ingredient() { Name = "Cream", Quantity = "200ml" });
            ingredients.Add(new Ingredient() { Name = "Butter", Quantity = "100g" });
            ingredients.Add(new Ingredient() { Name = "Salad", Quantity = "1" });
            ingredients.Add(new Ingredient() { Name = "Carrots", Quantity = "5" });

            List<string> steps = new()
            {
                "Put Bread in the oven",
                "Put beef between the bread",
                "Add any toppings"
            };

            Recipe r1 = new Recipe("Burger", "Miam miam", "25min", ingredients, steps);
            Recipe r2 = new Recipe("Pasta", "Miam miam", "30min", ingredients, steps);
            Recipe r3 = new Recipe("Pizza", "MAMAMIA", "45min", ingredients, steps);

            Recipes.Add(r1);
            Recipes.Add(r2);
            Recipes.Add(r3);
        }

        Task<bool> IDataStore.AddRecipeAsync(Recipe recipe)
        {
            Recipes.Add(recipe);
            return Task.FromResult(true);
        }

        Task<bool> IDataStore.UpdateRecipeAsync(Recipe recipe, int index)
        {
            Recipes[index] = recipe;
            return Task.FromResult(true);
        }

        Task<bool> IDataStore.DeleteRecipeAsync(Recipe recipe)
        {
            Recipes.Remove(recipe);
            return Task.FromResult(true);
        }

        Task<Recipe> IDataStore.GetRecipeAsync(int id)
        {
            return Task.FromResult(Recipes[id]);
        }

        Task<List<Recipe>> IDataStore.GetRecipesAsync()
        {
            return Task.FromResult(Recipes);
        }
    }
}
