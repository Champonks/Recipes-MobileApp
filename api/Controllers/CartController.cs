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
            return Ok(_map.Map<IEnumerable<CartItemReadDTO>>(_dataStore.GetCartItems(userToken)));
        }

        [HttpPost]
        public ActionResult AddCartItem(CartItemWriteDTO cartDTO)
        {
            CartItem cartItem = _map.Map<CartItem>(cartDTO);
            _dataStore.AddCartItem(cartItem);
            _dataStore.SaveChanges();
            return Ok();
        }
    }
}