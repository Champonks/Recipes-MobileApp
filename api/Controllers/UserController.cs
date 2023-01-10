using api.Datastores;
using api.DTO;
using api.Model;
using api.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IDataStore _dataStore;
        private readonly IMapper _map;

        public UserController(IDataStore dataStore, IMapper mapper)
        {
            _dataStore = dataStore;
            _map = mapper;
        }

        [HttpGet]
        public ActionResult Connect(string login, string password)
        {
            User u = _dataStore.Connect(login, password);
            if (u == null)
                return NotFound();
            UserConnectedReadDTO userConnected = _map.Map<UserConnectedReadDTO>(u);
            //because we change the token, we need to save the changes
            _dataStore.SaveChanges();
            return Ok(userConnected);
        }

        [HttpGet("{login}", Name = nameof(GetUser))]
        public ActionResult GetUser(string login)
        {
            User user = _dataStore.GetUserInfos(login);
            if (user == null)
                return NotFound();
            return Ok(_map.Map<UserReadDTO>(user));
        }

        [HttpPost]
        public ActionResult AddUser(UserWriteDTO userDTO)
        {
            User user = _map.Map<User>(userDTO);
            if (_dataStore.GetUserInfos(user.Login) != null)
                return BadRequest();
            
            _dataStore.AddUser(user);
            _dataStore.SaveChanges();
            //return CreatedAtRoute(nameof(Connect), new {login = user.Login, password = user.Password}, _map.Map<UserConnectedReadDTO>(user));
            return Ok();
        }

        [HttpDelete("{userToken}", Name = nameof(DeleteUser))]
        public ActionResult DeleteUser(string userToken)
        {
            User user = _dataStore.GetUserByToken(userToken);
            if (user == null)
                return NotFound();
            _dataStore.DeleteUser(user);
            _dataStore.SaveChanges();
            return Ok();
        }
    }
}