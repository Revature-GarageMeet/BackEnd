using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Models;
using Datalayer;
using WebAPI.Controllers;

namespace Tests
{
    public class LoginTest
    {
        //This class tests things related to the user and logging in ~leo
        public Mock<DBInterface> mock = new Mock<DBInterface>();

        //User Models
        [Fact]
        public void GetSetUserID()
        {
            User user = new User();
            user.id = 1;

            Assert.Equal(1, user.id);
        }
        [Fact]
        public void GetSetUsername()
        {
            User user = new User();
            user.username = "1";

            Assert.Equal("1", user.username);
        }
        [Fact]
        public void GetSetPassword()
        {
            User user = new User();
            user.password = "1";

            Assert.Equal("1", user.password);
        }
        [Fact]
        public void GetSetFirstName()
        {
            User user = new User();
            user.firstname = "1";

            Assert.Equal("1", user.firstname);
        }
        [Fact]
        public void GetSetLastName()
        {
            User user = new User();
            user.lastname = "1";

            Assert.Equal("1", user.lastname);
        }
        [Fact]
        public void GetSetEmail()
        {
            User user = new User();
            user.email = "1";

            Assert.Equal("1", user.email);
        }
        [Fact]
        public void GetSetBio()
        {
            User user = new User();
            user.bio = "1";

            Assert.Equal("1", user.bio);
        }

        //Controller Tests
        [Fact]
        public async Task CheckCreate()
        {
            User user = new User()
            {
                id = 1,
                username = "username",
                password = "password",
                firstname = "firstname",
                lastname = "lastname",
                email = "email",
                bio = "bio"
            };

            User cUser = new User()
            {
                id = 1,
                username = "username",
                password = "password",
                firstname = "firstname",
                lastname = "lastname",
                email = "email",
                bio = "bio"
            };

            mock.Setup(p => p.createUser(user)).ReturnsAsync(cUser);
            UserController userController = new UserController(mock.Object);
            User result = await userController.createUser(user);
            Assert.Equal(cUser, result);

        }
        [Fact]
        public async Task CheckLogin()
        {
            User user = new User()
            {
                id = 1,
                username = "username",
                password = "password",
                firstname = "firstname",
                lastname = "lastname",
                email = "email",
                bio = "bio"
            };

            User cUser = new User()
            {
                id = 1,
                username = "username",
                password = "password",
                firstname = "firstname",
                lastname = "lastname",
                email = "email",
                bio = "bio"
            };

            mock.Setup(p => p.loginUser(user.username)).ReturnsAsync(cUser);
            UserController userController = new UserController(mock.Object);
            User result = await userController.login(user.username);
            Assert.Equal(cUser, result);
        }
        [Fact]
        public async Task CheckExisting()
        {
            
        }
        [Fact]
        public async Task CheckAuthenticate()
        {

        }
        [Fact]
        public async Task CheckUpdate()
        {
            User user = new User()
            {
                id = 1,
                username = "username",
                password = "password",
                firstname = "firstname",
                lastname = "lastname",
                email = "email",
                bio = "bio"
            };

            User cUser = new User()
            {
                id = 1,
                username = "username",
                password = "password",
                firstname = "firstname",
                lastname = "lastname",
                email = "email",
                bio = "bio"
            };

            mock.Setup(p => p.updateUser(user)).ReturnsAsync(cUser);
            UserController userController = new UserController(mock.Object);
            User result = await userController.updateUser(user);
            Assert.Equal(cUser, result);
        }
        [Fact]
        public async Task CheckOther()
        {
            User user = new User()
            {
                id = 1,
                username = "username",
                password = "password",
                firstname = "firstname",
                lastname = "lastname",
                email = "email",
                bio = "bio"
            };

            User cUser = new User()
            {
                id = 1,
                username = "username",
                password = "",
                firstname = "firstname",
                lastname = "lastname",
                email = "",
                bio = "bio"
            };

            mock.Setup(p => p.otherProfileInfo(user.id)).ReturnsAsync(cUser);
            UserController userController = new UserController(mock.Object);
            User result = await userController.otherUserProfileInfo(user.id);
            Assert.Equal(cUser, result);
        }
        /*
            task user createUser(user user)
            task user loginUser (string username)
            task bool checkExisting (string username)
            task bool authenticateUser(string username, string password)
            task user updateUser
            task user otherProfileInfo(int id)
        */
    }
}