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
        public UserInfoRepository(MatchmakingContext userInfoContext) : base(userInfoContext)
        {

        }
        public MatchmakingContext UserInfoContext
        {
            get
            {
                return base.Context as MatchmakingContext;
            }
        }

        public UserInfo GetInfoWithGuid(Guid id)
        {
            return UserInfoContext.UserInfos.FirstOrDefault(x => x.IdentityFK == id);
        }
    }
}
