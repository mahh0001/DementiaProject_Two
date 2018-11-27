using DementiaProject_Two.Models.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestEnv.Repo
{
    public interface IMockRepo
    {
        List<Login> GetUser();
    }
}
