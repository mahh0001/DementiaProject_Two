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
        public UserInfoRepository(MatchmakingContext matchmakingContext) : base(matchmakingContext)
        {

        }

        public MatchmakingContext MatchmakingContext
        {
            get
            {
                return base.Context as MatchmakingContext;
            }
        }

        public UserInfo GetInfoWithGuid(Guid id)
        {
            return MatchmakingContext.UserInfos.FirstOrDefault(x => x.IdentityFK == id);
        }
    }
}
