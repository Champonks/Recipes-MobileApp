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
        public List<Ingredient> Cart { get ; set; }

        public MockDataStore()
        {
            Recipes = new List<Recipe>();
            Cart = new List<Ingredient>();
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

            List<Ingredient> ingredients2 = new()
            {
                new Ingredient() { Name = "Cream", Quantity = "1L" },
                new Ingredient() { Name = "Curry", Quantity = "5g" },
                new Ingredient() { Name = "Rice", Quantity = "1kg" },
                new Ingredient() { Name = "Chicken", Quantity = "600g" }
            };

            List<Ingredient> ingredientsRaclette = new()
            {
                new Ingredient() { Name = "Raclette", Quantity = "600g" },
                new Ingredient() { Name = "Charcuterie", Quantity = "1kg" },
                new Ingredient() { Name = "Potatoes", Quantity = "2kg" },
                new Ingredient() { Name = "Vegetables", Quantity = "600g" }
            };

            List<string> steps = new()
            {
                "Put Bread in the oven",
                "Put beef between the bread",
                "Add any toppings"
            };

            List<string> steps2 = new()
            {
                "Cook the chicken",
                "Add the curry sauce",
                "Add the rice",
                "Add the vegetables"
            };

            List<string> stepsRaclette = new()
            {
                "Cook the potatoes",
                "Dispose the meet",
                "Add the melting cheese",
                "Add the vegetables"
            };

            Recipe r0 = new("Chicken Curry", "Awesome chicken with wonderful curry spicy.", 6, CookingSeason.Winter, "35min", ingredients2, steps2);
            Recipe r1 = new("burger.jpg", "Burger", "Miam miam", 4, CookingSeason.All, "25min", ingredients, steps);
            Recipe r2 = new("pates.jpg", "Pasta", "Italia", 2, CookingSeason.All, "30min", ingredients, steps);
            Recipe r3 = new("pizza.jpg", "Pizza", "MAMAMIA", 6, CookingSeason.Autumn, "45min", ingredients, steps);
            Recipe r4 = new("raclette.jpg", "Raclette", "Delicious winter recipe", 12, CookingSeason.Winter, "20min", ingredientsRaclette, stepsRaclette);

            Recipes.Add(r4);
            Recipes.Add(r1);
            Recipes.Add(r2);
            Recipes.Add(r0);
            Recipes.Add(r3);

            Cart.Add(new Ingredient { Name = "Chicken", Quantity = "200g" });
            Cart.Add(new Ingredient { Name = "Tomato", Quantity = "4" });
            Cart.Add(new Ingredient { Name = "Potatoes", Quantity = "10" });
            Cart.Add(new Ingredient { Name = "Cheese", Quantity = "200g" });
        }

        Task<bool> IDataStore.AddRecipeAsync(Recipe recipe)
        {
            Recipes.Add(recipe);
            return Task.FromResult(true);
        }

        Task<bool> IDataStore.DeleteRecipeAsync(Recipe recipe)
        {
            Recipes.Remove(recipe);
            return Task.FromResult(true);
        }

        Task<List<Recipe>> IDataStore.GetRecipesAsync(int start, int count)
        {
            int nbRecipes = Recipes.Count;
            if (start < nbRecipes && nbRecipes != 0)
            {
                if (count > (nbRecipes - start)) count = (nbRecipes - start);
                return Task.FromResult(Recipes.GetRange(start, count));
            } else
            {
                return Task.FromResult<List<Recipe>>(null);
            }
        }

        public Task<List<Recipe>> GetSeasonalRecipesAsync(int count)
        {
            CookingSeason season;
            DateTime now = DateTime.Now;
            if (now.Month >= 3 && now.Month <= 5)
            {
                season = CookingSeason.Spring;
            }
            else if (now.Month >= 6 && now.Month <= 8)
            {
                season = CookingSeason.Summer;
            }
            else if (now.Month >= 9 && now.Month <= 11)
            {
                season = CookingSeason.Autumn;
            }
            else 
            {
                season = CookingSeason.Winter;
            }
            //get 'count' recipes from the current season or all season
            List<Recipe> seasonalRecipes = Recipes.Where(r => (r.RecipeSeason == season) || (r.RecipeSeason == CookingSeason.All)).Take(count).ToList();
            return Task.FromResult(seasonalRecipes);
        }

        public Task<List<Ingredient>> GetCartAsync()
        {
            return Task.FromResult(Cart);
        }

        public Task<bool> AddToCartAsync(Ingredient ingredient)
        {
            Cart.Add(ingredient);
            return Task.FromResult(true);
        }

        public Task<bool> AddAllToCartAsync(List<Ingredient> ingredient)
        {
            Cart.AddRange(ingredient);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteFromCartAsync(Ingredient ingredient)
        {
            Cart.Remove(ingredient);
            Console.WriteLine(Cart.Count ); 
            return Task.FromResult(true);
        }

        public Task<bool> DeleteMultipleFromCartAsync(List<Ingredient> ingredients)
        {
            if (ingredients == Cart)
            {
                Cart.Clear();
            }
            else
            { 
                foreach (Ingredient ingredient in ingredients)
                {
                    Cart.Remove(ingredient);
                }
            }
            return Task.FromResult(true);
        }

        public Task<List<Recipe>> GetAllRecipesAsync()
        {
            return Task.FromResult(Recipes);
        }
    }
}