using CoreSolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    //TODO kan registrera och logga in med mer än en användare
    public class LoginTests
    {
        private LoginManager _manager;

        public LoginTests()
        {
            _manager = new LoginManager();
        }

        [Fact]
        void TestUserRegistration()
        {
            //act
            bool couldRegister = _manager.RegisterNewUser("usr_name", "123pwd");

            //assert
            Assert.True(couldRegister);
        }

        [Fact]
        void TestRegisteredUserCanLogin()
        {
            //act
            bool loginFailed = _manager.TryLogin("usr_name", "123pwd");
            _manager.RegisterNewUser("usr_name", "123pwd");
            bool loginSuccessful = _manager.TryLogin("usr_name", "123pwd");

            //assert
            Assert.False(loginFailed);
            Assert.True(loginSuccessful);
        }

        [Theory]
        [InlineData("usr_name", "123pwd", false)]
        [InlineData("usr_name", "new_pwd", false)]
        [InlineData("new_usr", "123pwd", true)]
        void TestUnableToRegisterSameUserTwice(string username, string password, bool registerCorrectResult)
        {
            //arrange
            _manager.RegisterNewUser("usr_name", "123pwd");

            //act
            bool canRegister = _manager.RegisterNewUser(username, password);

            //assert
            Assert.Equal(registerCorrectResult, canRegister);
        }
    }
}
