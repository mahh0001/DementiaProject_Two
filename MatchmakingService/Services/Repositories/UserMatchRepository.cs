using MatchmakingService.DataContext;
using MatchmakingService.Helpers;
using MatchmakingService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchmakingService.Services.Repositories
{
    // Update the fucking interface!!!
    public class UserMatchRepository : Repository<UserMatch>, IUserMatchRepository
    {
        public UserMatchRepository(MatchmakingContext matchmakingContext) : base(matchmakingContext) { }

        public MatchmakingContext MatchmakingContext
        {
            get
            {
                return base.Context as MatchmakingContext;
            }
        }

        // Skroll first through
        public UserInfo FindRandomUser(Guid userId)
        {
            var allUsers = MatchmakingContext.UserInfos
                .Include(x => x.Matches)
                .Where(x => x.IdentityFK != userId)
                .ToList();
            List<UserInfo> correctList = new List<UserInfo>();
            foreach (var user in allUsers) {
                if (
                    (user.Matches.Where(x => x.User2Id == userId && x.FirstSelection == true && x.IsAMatch == null).Count() > 0) ||
                    (user.Matches.Where(x => x.User2Id != userId).Count() == 0)                    
                    ) {
                    correctList.Add(user);
                }
            }

            //// needs to do some kind of random selection on the correctList and return that UserInfo

            return null;
        }
    }
}