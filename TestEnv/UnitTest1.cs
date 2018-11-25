using System;
using Xunit;
using DementiaProject_Two.Models.Account;

namespace TestEnv
{
    public class RegistrationShould
    {
        [Theory]
        [InlineData("rasmusvm6@hotmail.com")]
        public void ContainValidEmail(string email)
        {
            var sut = new Registration();
            
            Assert.True(email == sut.Password);
        }
    }
}
