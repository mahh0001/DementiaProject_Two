using DementiaProject_Two.Models.Account;
using System;

namespace DementiaProject_Two.Repositories
{
    public interface IRepository
    {
        UserInformationModel GetUserInfoByEmail(string email);
        UserInformationModel Update(UserInformationModel userInfo);
    }
}
