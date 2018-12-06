using DementiaProject_Two.Models.Account;
using System.Collections.Generic;

namespace TestEnv.Repo
{
    public interface IMockRepo
    {
        List<Login> GetUser();
    }
}
