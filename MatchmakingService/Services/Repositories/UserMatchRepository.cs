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
            List<UserInfo> allUsers = MatchmakingContext.UserInfos
                .Include(x => x.Matches)
                .Where(x => x.IdentityFK != userId)
                .ToList();
            foreach (var user in allUsers) {
                // removes users from list, if user dosn't wan't to match or if both users already matched.
                if ( 
                    (user.Matches.Where(x => x.User2Id == userId && x.FirstSelection == false).Count() == 1) ||
                    (user.Matches.Where(x => x.User2Id == userId && x.IsAMatch == true).Count() == 1)
                    )
                {
                    allUsers.Remove(user);
                }
            }

            //// needs to do some kind of random selection on the allUsers and return that UserInfo

            return null;
        }
    }
}