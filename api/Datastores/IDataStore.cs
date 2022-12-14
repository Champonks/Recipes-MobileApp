using api.DTO;
using api.Model;

namespace api.Datastores
{
    public interface IDataStore
    {
        public Ingredient GetIngredientById(int id);
        public IEnumerable<Ingredient> GetIngredientsByRecipeId(int recipeId);
        public IEnumerable<Step> GetStepsByRecipeId(int recipeId);

        public IEnumerable<Recipe> GetAllRecipes();
        public Recipe GetRecipeById(int id);
        public IEnumerable<Recipe> GetSeasonalRecipes(int count);
        public void AddRecipe(Recipe recipe);
        public void DeleteRecipe(Recipe r);


        public IEnumerable<CartItem> GetCartItems(string userToken);
        public CartItem GetCartItemById(int id);
        public IEnumerable<CartItem> GetCartItemsById(IEnumerable<int> ids);
        public void AddCartItem(CartItem cartItem);
        public void AddCartItems(IEnumerable<CartItem> cartItems);
        public void DeleteCartItem(CartItem cartItem);
        public void DeleteCartItems(IEnumerable<CartItem> cartItems);

        public User Connect(string login, string password);
        public User GetUserByToken(string token);
        public User GetUserInfos(string login);
        public void AddUser(User user);

        public void SaveChanges();
    }
}
