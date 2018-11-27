using MatchmakingService.DataContext;
using MatchmakingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchmakingService.Services.Repositories
{
    public class UserInfoRepository : Repository<UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(UserInfoContext userInfoContext) : base(userInfoContext)
        {

        }
    }
}
