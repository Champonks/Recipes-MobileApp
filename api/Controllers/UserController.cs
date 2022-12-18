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

        //just get generated token since users have no infos for the moment
        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult GetUser(string login, string password)
        {
            return Ok(_map.Map<UserReadDTO>(_dataStore.GetUser(login, password)));
        }

        [HttpPost]
        public ActionResult AddUser(UserWriteDTO userDTO)
        {
            User user = _map.Map<User>(userDTO);
            _dataStore.AddUser(user);
            _dataStore.SaveChanges();
            return CreatedAtRoute(nameof(GetUser), new { login = user.Login, password = user.Password }, _map.Map<UserReadDTO>(user));
        }
    }
}