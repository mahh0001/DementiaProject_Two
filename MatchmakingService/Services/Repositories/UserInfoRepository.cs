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
        public UserInfoContext UserInfoContext
        {
            get
            {
                return base.Context as UserInfoContext;
            }
        }

        public UserInfo GetInfoWithGuid(Guid id)
        {
            return UserInfoContext.UserInfos.FirstOrDefault(x => x.IdentityFK == id);
        }
    }
}
