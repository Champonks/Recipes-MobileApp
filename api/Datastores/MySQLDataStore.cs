using api.Contexts;
using api.Model;
using api.Utilities;

namespace api.Datastores
{
    public class MySQLDataStore : IDataStore
    {
        private CookUsContext _context;

        public MySQLDataStore(CookUsContext context)
        {
            _context = context;
        }

//------------------User------------------//

        public User Connect(string login, string password)
        {
            User user = _context.Users.FirstOrDefault<User>(u => u.Login == login && u.Password == password);
            if (user == null)
                return null;
            renewToken(user.Login);
            return user;
        }

        string renewToken(string login) {
            User user = _context.Users.FirstOrDefault<User>(u => u.Login == login);
            if (user == null)
                return null;
            user.Token = RandomToken.TokenGenerator();
            _context.Users.Update(user);
            return user.Token;
        }
        
        public User GetUserByToken(string token)
        {
            return _context.Users.FirstOrDefault<User>(u => u.Token == token);
        }

        public User GetUserInfos(string login)
        {
            return _context.Users.FirstOrDefault<User>(u => u.Login == login);
        }

        public void AddUser(User user)
        {
            user.Token = RandomToken.TokenGenerator();
            _context.Users.Add(user);
        }

//------------------Recipe------------------//

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _context.Recipes;
        }

        public Recipe GetRecipeById(int id)
        {
            return _context.Recipes.FirstOrDefault<Recipe>(r => r.Id == id);
        }

        public IEnumerable<Recipe> GetSeasonalRecipes(int count) {
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
            return _context.Recipes.Where(r => (r.RecipeSeason == season) || (r.RecipeSeason == CookingSeason.All)).Take(count).ToList();
        }
        public void AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
        }

        public void DeleteRecipe(Recipe r)
        {
            _context.Recipes.Remove(r);
        }

        public Ingredient GetIngredientById(int id)
        {
            System.Console.WriteLine(_context.Ingredients.FirstOrDefault<Ingredient>(i => i.Id == id).Name);
            //_context.Ingredients.FirstOrDefault<Ingredient>(i => i.Id == id)
            return new Ingredient() { Id = 1, Name = "test", Quantity = "200g", RecipeId = 1 };
        }
        public IEnumerable<Ingredient> GetIngredientsByRecipeId(int recipeId)
        {
            return _context.Ingredients.Where(i => i.RecipeId == recipeId);
        }

        public IEnumerable<Step> GetStepsByRecipeId(int recipeId)
        {
            return _context.Steps.Where(s => s.RecipeId == recipeId);
        }

//------------------Cart------------------//

        public IEnumerable<CartItem> GetCartItems(string userToken)
        {
            User user = GetUserByToken(userToken);
            if (user == null)
                return null;
            //make a correspondance between user login in cart and user token in user table
            return _context.Cart.Where(c => c.UserLogin == user.Login);
        }

        public CartItem GetCartItemById(int id)
        {
            return _context.Cart.FirstOrDefault<CartItem>(c => c.Id == id);
        }

        public IEnumerable<CartItem> GetCartItemsById(IEnumerable<int> ids)
        {
            return _context.Cart.Where(c => ids.Contains(c.Id));
        }

        public void AddCartItem(CartItem cartItem)
        {
            _context.Cart.Add(cartItem);
        }

        public void AddCartItems(IEnumerable<CartItem> cartItems)
        {
            _context.Cart.AddRange(cartItems);
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            _context.Cart.Remove(cartItem);
        }

        public void DeleteCartItems(IEnumerable<CartItem> cartItems)
        {
            _context.Cart.RemoveRange(cartItems);
        }



        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}