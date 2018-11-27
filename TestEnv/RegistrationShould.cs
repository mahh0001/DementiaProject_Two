using System;
using Xunit;
using DementiaProject_Two.Models.Account;
using System.Threading.Tasks;
using TestEnv.Repo;
using Moq;
using DementiaProject_Two.Controllers;

namespace TestEnv
{
    public class RegistrationShould
    {
        [Fact]
        public void LoginUser()
        {
            //Arrange 
            var mockRepo = new Mock<IMockRepo>();
            //var sut = new AccountController(mockRepo.Object);

            //Act

            //Assert
        }
    }
}
