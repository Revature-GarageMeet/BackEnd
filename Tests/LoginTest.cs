using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore; //dotnet add package Microsoft.EntityFrameworkCore.Sqlite

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using Models;
using Datalayer;
using WebAPI.Controllers;

namespace Tests
{
    public class LoginTest
    {
        //This class tests things related to the user and logging in ~leo
        public Mock<DBInterface> mock = new Mock<DBInterface>();
        //Create and inject options for the DBContext
        private readonly DbContextOptions<GMDBContext> options;
        public LoginTest()
        {
            //set options up to use a sqlite db called test.db
            options = new DbContextOptionsBuilder<GMDBContext>()
                    .UseSqlite("Filename=test.db").Options;
            //call next method below
            Seed();
        }

        private void Seed()
        {
            //this method sets up the db and ensures that the db is reset every time we test
            using (var context = new GMDBContext(options))
            {
                //methods are self explanatory what they do, delete -> create -> save
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //adding a default to the db, this is used to test below
                context.Users.Add(
                    new User()
                    {
                        id = 1,
                        username = "test",
                        password = "user",
                        firstname = "firstname",
                        lastname = "lastname",
                        email = "email",
                        bio = "bio"
                    }
                );
                context.SaveChanges();
            }
        }
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
        // [Fact]
        // public async Task CheckExisting()
        // {
        //     //idunno, theoretically, you add a user to db and then check if the name matches
        //     //but i dont think moq actually keeps a db for you to do that with?
        //     //would prob need to not use moq
        // }
        // [Fact]
        // public async Task CheckAuthenticate()
        // {
        //     //see comment on DBCheckAuth, implement it after uncommenting -> fixing up it in the UserController, DatabaseCalls and DBInterface classes
        //     //might have the same issues as above
        // }
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

        //DB Calls
        [Fact]
        public void DBCreateUser()
        {
            // create the test user and insert into the db
            using (var context = new GMDBContext(options))
            {
                DBInterface repo = new DatabaseCalls(context);
                User test = new User()
                {
                    id = 2,
                    username = "username",
                    password = "password",
                    firstname = "firstname",
                    lastname = "lastname",
                    email = "email",
                    bio = "bio"
                };
                repo.createUser(test);
            }

            //pull the user by id of 2, should be the test user made above
            using (var context = new GMDBContext(options))
            {
                User tester = context.Users.FirstOrDefault(r => r.id == 2);
                //check if not null -> check if matches above
                Assert.NotNull(tester);
                Assert.Equal("username", tester.username);
                Assert.Equal("password", tester.password);
                Assert.Equal("firstname", tester.firstname);
                Assert.Equal("lastname", tester.lastname);
                Assert.Equal("email", tester.email);
                Assert.Equal("bio", tester.bio);
            }
        }
        [Fact]
        public async Task DBLoginUser()
        {
            //get the user matching the user's name
            using (var context = new GMDBContext(options))
            {
                DBInterface repo = new DatabaseCalls(context);

                User loginTest = await repo.loginUser("test");

                //test if matches
                Assert.NotNull(loginTest);
                Assert.Equal(1, loginTest.id);
                Assert.Equal("test", loginTest.username);
                Assert.Equal("user", loginTest.password);
                Assert.Equal("firstname", loginTest.firstname);
                Assert.Equal("lastname", loginTest.lastname);
                Assert.Equal("email", loginTest.email);
                Assert.Equal("bio", loginTest.bio);
            }
        }

        [Fact]
        public async void DBCheckExisting()
        {
            using (var context = new GMDBContext(options))
            {
                //check if username exists already
                DBInterface repo = new DatabaseCalls(context);

                Boolean existing = await repo.checkExisting("test");

                Assert.True(existing);
            }
        }

        // [Fact]
        // public async void DBCheckAuth()
        // {
            //we never called this so imma just not test it
            //if you're looking at this in the near/far future heres how to fix it
            /*
                currently authenticateUser isn't implemented in DatabaseCalls.cs because
                we arent using it in our frontend at all, check login.service.ts to confirm
                it technically is implemented, but implemented incorrectly. 
                just change the 'string authUser, string authPass' to 'User auth'
                and within the return statement, change 'authUser' -> 'auth.username' and do the same for password, ya can figure it out ~leo
            */


            // using (var context = new GMDBContext(options))
            // {
            //     DBInterface repo = new DatabaseCalls(context);
            //     User test = new User()
            //     {
            //         id = 0,
            //         username = "test",
            //         password = "user",
            //         firstname = "",
            //         lastname = "",
            //         email = "",
            //         bio = ""
            //     };

            //     Boolean auth = await repo.authenticateUser(test);

            //     Assert.True(auth);
            // }
        // }

        [Fact]
        public async Task DBOtherUser()
        {
            //get the user matching the user's name
            using (var context = new GMDBContext(options))
            {
                DBInterface repo = new DatabaseCalls(context);

                User loginTest = await repo.otherProfileInfo(1);

                //test if matches, password and email shouldnt be visible/blank
                Assert.NotNull(loginTest);
                Assert.Equal(1, loginTest.id);
                Assert.Equal("test", loginTest.username);
                Assert.Equal("", loginTest.password);
                Assert.Equal("firstname", loginTest.firstname);
                Assert.Equal("lastname", loginTest.lastname);
                Assert.Equal("", loginTest.email);
                Assert.Equal("bio", loginTest.bio);
            }
        }
        [Fact]
        public async void UpdateUser()
        {
            // This method assumes you got past the login fine and dandy, they didnt want to push password to check auth so it just cares about username.
            using (var context = new GMDBContext(options))
            {
                DBInterface repo = new DatabaseCalls(context);
                User testUpdate = new User()
                {
                    id = 0,
                    username = "test",
                    password = "",
                    firstname = "",
                    lastname = "",
                    email = "",
                    bio = ""
                };

                User testResult = await repo.updateUser(testUpdate);
                //it only changes firstname lastname and bio
                Assert.NotNull(testResult);
                Assert.Equal(1, testResult.id);
                Assert.Equal("test", testResult.username);
                Assert.Equal("user", testResult.password);
                Assert.Equal("", testResult.firstname);
                Assert.Equal("", testResult.lastname);
                Assert.Equal("email", testResult.email);
                Assert.Equal("", testResult.bio);
            }
        }
    }
}