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

        public MockDataStore() => Recipes = new List<Recipe>();

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
