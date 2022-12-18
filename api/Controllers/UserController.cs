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
            var res = Ok(_map.Map<UserConnectedReadDTO>(_dataStore.Connect(login, password)));
            //because whe change the token, we need to save the changes
            _dataStore.SaveChanges();
            return res;
        }

        [HttpGet("{login}", Name = nameof(GetUser))]
        public ActionResult GetUser(string login)
        {
            return Ok(_map.Map<UserReadDTO>(_dataStore.GetUserInfos(login)));
        }

        [HttpPost]
        public ActionResult AddUser(UserWriteDTO userDTO)
        {
            User user = _map.Map<User>(userDTO);
            _dataStore.AddUser(user);
            _dataStore.SaveChanges();
            // return CreatedAtRoute(nameof(GetUser), new {
            //     login = user.Login, password = user.Password
            //     }, new {
            //     Login = user.Login, Password = user.Password
            //     });
            return Ok();
        }
    }
}