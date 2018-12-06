using DementiaProject_Two.Models.Account;
using System;

namespace DementiaProject_Two.Repositories
{
    public interface IRepository
    {
        UserInformationModel Get(string id);
        UserInformationModel Update(UserInformationModel userInfo);
    }
}
