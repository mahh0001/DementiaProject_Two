using DementiaProject_Two.DataContexts;
using DementiaProject_Two.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DementiaProject_Two.Repositories
{
    public class UserInfoRepository : IRepository
    {
        private UserInformationContext context;

        public UserInfoRepository(UserInformationContext context)
        {
            this.context = context;
        }

        public void AddUserInfo(UserInformationModel userinfo)
        {
            context.UserInformations.Add(userinfo);
            context.SaveChanges();
        }

        public UserInformationModel GetUserInfoByEmail(string  email)
        {
            return context.UserInformations.FirstOrDefault(x => x.Email == email);
        }

        public UserInformationModel Update(UserInformationModel userInfo)
        {
            context.UserInformations.Update(userInfo);
            context.SaveChanges();
            return userInfo;
        }
    }
}
