using api.Datastores;
using api.DTO;
using api.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly IDataStore _dataStore;
        private readonly IMapper _map;

        public CartController(IDataStore dataStore, IMapper mapper)
        {
            _dataStore = dataStore;
            _map = mapper;
        }

        [HttpGet("{userToken}", Name = "GetUserItemsFromCart")]
        public ActionResult GetUserItemsFromCart(string userToken)
        {
            if (_dataStore.GetUserByToken(userToken) == null)
                return BadRequest();

            var items = _dataStore.GetCartItems(userToken);
            if (items == null) {
                return NotFound();
            }
            IEnumerable<CartItemReadDTO> itemsDTO = _map.Map<IEnumerable<CartItemReadDTO>>(items);

            return Ok(itemsDTO);
        }

        [HttpPost("add/{userToken}", Name = nameof(AddCartItems))]
        public ActionResult AddCartItems(List<int> itemsId, string userToken)
        {
            User u = _dataStore.GetUserByToken(userToken);
            if (u == null)
                return BadRequest();

            List<CartItem> cartItems = new List<CartItem>();
            foreach (int id in itemsId) {
                Ingredient i = _dataStore.GetIngredientById(id);
                if (i == null) 
                    return BadRequest();
                cartItems.Add(new CartItem { IngredientId = id, UserLogin = u.Login });
            }

            _dataStore.AddCartItems(cartItems);
            _dataStore.SaveChanges();
            return Ok();
        }

        [HttpDelete("{userToken}", Name = nameof(DeleteCartItem))]
        public ActionResult DeleteCartItem(int id, string userToken)
        {
            User user = _dataStore.GetUserByToken(userToken);
            if (user == null)
                return BadRequest();

            CartItem cartItem = _dataStore.GetCartItemById(id);
            if (cartItem == null)
                return NotFound();
            if (cartItem.UserLogin != user.Login)
                return Unauthorized();
            
            _dataStore.DeleteCartItem(cartItem);
            _dataStore.SaveChanges();
            return Ok();
        }
    }
}