using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            Recipe r1 = new("Burger", "Miam miam", 4, "25min", ingredients, steps);
            Recipe r2 = new("Pasta", "Italia", 2, "30min", ingredients, steps);
            Recipe r3 = new("Pizza", "MAMAMIA", 6, "45min", ingredients, steps);

            Recipes.Add(r1);
            Recipes.Add(r2);
            Recipes.Add(r3);
            Recipes.Add(r3);
            Recipes.Add(r3);
            Recipes.Add(r3);
            Recipes.Add(r3);
            Recipes.Add(r3);
            Recipes.Add(r3);
            Recipes.Add(r3);
            Recipes.Add(r3);
            Recipes.Add(r3);
            Recipes.Add(r3);
            Recipes.Add(r3);
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

        Task<List<Recipe>> IDataStore.GetRecipesAsync(int start, int count)
        {
            int nbRecipes = Recipes.Count;
            if (start < nbRecipes)
            {
                if (count > (nbRecipes - start)) count = (nbRecipes - start);
                return Task.FromResult(Recipes.GetRange(start, count));
            } else
            {
                return null;
            }
        }
    }
}