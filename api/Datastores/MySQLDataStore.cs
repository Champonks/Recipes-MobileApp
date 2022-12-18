using api.Contexts;
using api.Model;
using api.Utilities;

namespace api.Datastores
{
    public class MySQLDataStore : IDataStore
    {
        private readonly CookUsContext _context;

        public MySQLDataStore(CookUsContext context)
        {
            _context = context;
        }

//------------------User------------------//
        //get user and generate token
        public User GetUser(string login, string password)
        {
            User user = _context.Users.FirstOrDefault<User>(u => u.Login == login && u.Password == password);
            user.Token = RandomToken.TokenGenerator();
            return user;
        }

        User GetUserByToken(string token)
        {
            return _context.Users.FirstOrDefault<User>(u => u.Token == token);
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
        public void AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
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

        public void AddCartItem(CartItem cartItem)
        {
            _context.Cart.Add(cartItem);
        }



        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}