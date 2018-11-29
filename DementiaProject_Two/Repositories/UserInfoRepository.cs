using DementiaProject_Two.DataContexts;
using DementiaProject_Two.Models.Account;
using Microsoft.AspNetCore.Identity;
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

        public UserInformationModel Get(int id)
        {
            return context.UserInformations.FirstOrDefault(x => x.Id == id);
        }
    }
}
