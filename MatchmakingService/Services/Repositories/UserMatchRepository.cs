using MatchmakingService.DataContext;
using MatchmakingService.Helpers;
using MatchmakingService.Models;
using Microsoft.AspNetCore.Mvc;
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
        public UserInfo FindRandomUser(Guid currentUser)
        {
            List<UserInfo> allUsers = MatchmakingContext.UserInfos //check if both users exist and user1 wants to match with user2 OR they havent decided/seen each other yet
                .Include(x => x.Matches.Where(y => (y.User1Id == x.IdentityFK && y.User2Id == currentUser && y.FirstSelection == true && y.IsAMatch == null) || y == null))
                .Where(x => x.IdentityFK != currentUser)
                .ToList();
            foreach (var user in allUsers)
            {
                // removes users from list, if user dosn't wan't to match or if both users already matched.
                if (
                    (user.Matches.Where(x => x.User2Id == currentUser && x.FirstSelection == false).Count() == 1) ||
                    (user.Matches.Where(x => x.User2Id == currentUser && x.IsAMatch == true).Count() == 1)
                    )
                {
                    allUsers.Remove(user);
                }
            }

            //// needs to do some kind of random selection on the allUsers and return that UserInfo

            return null;
        }

        public IActionResult SaveMatchChoice(Guid currentUser, Guid potentialMatchUser, bool match)
        {
            return null;
        }
    }
}