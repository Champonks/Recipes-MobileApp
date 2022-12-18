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
            var items = _dataStore.GetCartItems(userToken);
            if (items == null) {
                return NotFound();
            }
            List<CartItemReadDTO> itemsDTO = new List<CartItemReadDTO>();
            foreach (CartItem item in items) {
                CartItemReadDTO c = _map.Map<CartItemReadDTO>(item);
                System.Console.WriteLine(c.Id);
                c.Ingredient = _dataStore.GetIngredientById(item.IngredientId);
                itemsDTO.Add(c);
            }
            
            return Ok(itemsDTO);
        }

        [HttpPost("addOne")]
        public ActionResult AddCartItem(CartItemWriteDTO cartDTO)
        {
            CartItem cartItem = _map.Map<CartItem>(cartDTO);
            cartItem.UserLogin = _dataStore.GetUserByToken(cartDTO.UserToken).Login;
            _dataStore.AddCartItem(cartItem);
            _dataStore.SaveChanges();
            return CreatedAtRoute(nameof(GetUserItemsFromCart), new { userToken = cartDTO.UserToken }, _map.Map<CartItemReadDTO>(cartItem));
        }

        [HttpPost("addMultiple")]
        public ActionResult AddCartItems(IEnumerable<CartItemWriteDTO> cartDTO)
        {
            List<CartItem> cartItems = new List<CartItem>();
            foreach (CartItemWriteDTO ciDTO in cartDTO) {
                CartItem cartItem = _map.Map<CartItem>(ciDTO);
                cartItem.UserLogin = _dataStore.GetUserByToken(ciDTO.UserToken).Login;
                cartItems.Add(cartItem);
            }
            _dataStore.AddCartItems(cartItems);
            _dataStore.SaveChanges();
            return Ok();
        }

        [HttpDelete("deleteOne")]
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

        [HttpDelete("deleteMultiple")]
        public ActionResult DeleteCartItems(IEnumerable<int> ids, string userToken)
        {
            User user = _dataStore.GetUserByToken(userToken);
            if (user == null)
                return BadRequest();

            IEnumerable<CartItem> cartItems = _dataStore.GetCartItemsById(ids);
            if (cartItems == null)
                return NotFound();
            foreach (CartItem cartItem in cartItems) {
                if (cartItem.UserLogin != user.Login)
                    return Unauthorized();
            }
            
            _dataStore.DeleteCartItems(cartItems);
            _dataStore.SaveChanges();
            return Ok();
        }
    }
}