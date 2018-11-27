using DementiaProject_Two.Models.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestEnv.Repo
{
    class MockRepo : IMockRepo
    {
        public List<Login> GetUser()
        {
            var user = new List<Login>
            {
                new Login()
                {
                    Email = "Rasmusvm6@hotmail.com",
                    Password = "1234"
                },
                new Login()
                {
                    Email = "Hulla@mail.dk",
                    Password = "5678"
                }
            };

            return user;
        }
    }
}
