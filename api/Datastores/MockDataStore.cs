using api.Model;

namespace api.Datastores
{
    class MockDataStore : IDataStore
    {
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
        public MockDataStore()
        {
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

            List<Step> steps = new()
            {
                new Step() { Description = "Put Bread in the oven" },
                new Step() { Description = "Put beef between the bread" },
                new Step() { Description = "Add any toppings"}
            };

            Recipe r1 = new() {Image = "burger.jpg", Name = "Burger", Description = "Miam miam.", Servings = 4, RecipeSeason = CookingSeason.All, Time = "25min" };
            r1.Ingredients = ingredients;
            r1.Steps = steps;
            Recipe r2 = new() {Image = "pates.jpg", Name = "Pasta", Description = "Italian pastas.", Servings = 2, RecipeSeason = CookingSeason.All, Time = "15min" };
            r2.Ingredients = ingredients;
            r2.Steps = steps;
            Recipe r3 = new() {Image = "pizza.jpg", Name = "Pizza", Description = "4 Cheese Italian Pizza.", Servings = 6, RecipeSeason = CookingSeason.All, Time = "45min" };
            r3.Ingredients = ingredients;
            r3.Steps = steps;

            Recipes.Add(r1);
            Recipes.Add(r2);
            Recipes.Add(r3);
        }
        
        public IEnumerable<Recipe> GetAllRecipes()
        {
            return Recipes;
        }

        public void AddRecipe(Recipe recipe, string userToken)
        {
            Recipes.Add(recipe);
        }

        public void SaveChanges()
        {
        }

        public Recipe GetRecipeById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recipe> GetSeasonalRecipes(int count)
        {
            throw new NotImplementedException();
        }

        public void AddRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecipe(Recipe r)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CartItem> GetCartItems(string userToken)
        {
            throw new NotImplementedException();
        }

        public void AddCartItem(CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public void AddCartItems(IEnumerable<CartItem> cartItems)
        {
            throw new NotImplementedException();
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public void DeleteCartItems(IEnumerable<CartItem> cartItems)
        {
            throw new NotImplementedException();
        }

        public User Connect(string login, string password)
        {
            throw new NotImplementedException();
        }

        public User GetUserByToken(string token)
        {
            throw new NotImplementedException();
        }

        public User GetUserInfos(string login)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public CartItem GetCartItemById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CartItem> GetCartItemsById(IEnumerable<int> id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ingredient> GetIngredientsByRecipeId(int recipeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ingredient> GetStepsByRecipeId(int recipeId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Step> IDataStore.GetStepsByRecipeId(int recipeId)
        {
            throw new NotImplementedException();
        }

        public Ingredient GetIngredientById(int id)
        {
            throw new NotImplementedException();
        }
    }
}