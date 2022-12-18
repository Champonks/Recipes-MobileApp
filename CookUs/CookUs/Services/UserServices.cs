using CookUs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CookUs.Services
{
    public class UserServices : ApiServices
    {
        public UserServices()
        {
            client.BaseAddress = new Uri("http://localhost:8000/api/user/");
        }

        public async Task<bool> AddUserAsync(User user)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("", user);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<string> Connect(string username, string password)
        {
            HttpResponseMessage response = await client.GetAsync($"?Login={username}&Password={password}");
            if (response.IsSuccessStatusCode) return await response.Content.ReadAsStringAsync();
            return null;
        }

        public async Task<User> GetUserAsync(string username)
        {
            User user = await client.GetFromJsonAsync<User>(username);
            return user;
        }
    }
}
