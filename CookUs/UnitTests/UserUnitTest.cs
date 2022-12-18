using CookUs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class UserUnitTest
    {
        [Fact]
        public async void TestAddUser()
        {
            string name = "John Doe";
            string password = "password123";
            string login = "john.doe@example.com";
            // Arrange
            var user = new User
            {
                Name = name,
                Password = password,
                Login = login
            };

            var userServices = new UserServices();

            // Act
            bool isAdded = await userServices.AddUserAsync(user);
            
            User addedUser = await userServices.GetUserAsync(login);

            // Assert
            Assert.True(isAdded);
            Assert.Equal(user, addedUser);
            Assert.Equal(name, addedUser.Name);
            Assert.Equal(password, addedUser.Password);
            Assert.Equal(login, addedUser.Login);
        }

        public async void TestConnection()
        {
            string name = "John Doe";
            string password = "pass";
            string login = "john@gmail.com";
            // Arrange
            var user = new User
            {
                Name = name,
                Password = password,
                Login = login
            };

            var userServices = new UserServices();
            
            // Act
            bool isAdded = await userServices.AddUserAsync(user);
            string oldToken = await userServices.Connect(login, password);
            string newToken = await userServices.Connect(login, password);

            // Assert
            Assert.True(isAdded);
            Assert.NotEmpty(oldToken);
            Assert.NotEmpty(newToken);
            Assert.NotEqual(oldToken, newToken);

        }
    }
}
