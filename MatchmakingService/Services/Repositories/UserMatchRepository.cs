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

        public UserInfo FindRandomUser(Guid currentUser)
        {
            UserInfo potentialMatch = MatchmakingContext.UserInfos //check if both users exist and user1 wants to match with user2 OR they havent decided/seen each other yet
                .Include(x => x.Matches.Where(y => (y.User1Id == x.IdentityFK && y.User2Id == currentUser && y.FirstSelection == true && y.IsAMatch == null) || y == null))
                .Where(x => x.IdentityFK != currentUser)
                .FirstOrDefault();

            return potentialMatch;
        }

        public bool SaveMatchChoice(Guid currentUserId, Guid potentialMatchUserId, bool userMatch)
        {
            var currentUser = MatchmakingContext.UserInfos.FirstOrDefault(x => x.IdentityFK == currentUserId);
            var potentialMatchUser = MatchmakingContext.UserInfos.Include(x => x.Matches).FirstOrDefault(x => x.IdentityFK == potentialMatchUserId);

            if (potentialMatchUser.Matches.Where(x => x.User1Id == potentialMatchUserId && x.User2Id == currentUserId && x.FirstSelection == true).Count() == 1)
            {
                UserMatch match = potentialMatchUser.Matches.Where(x => x.User1Id == potentialMatchUserId && x.User2Id == currentUserId && x.FirstSelection == true).FirstOrDefault();
                match.IsAMatch = userMatch;
                MatchmakingContext.Update(match);
            }
            else
            {
                UserMatch newUserMatch = new UserMatch { User1 = currentUser, User2 = potentialMatchUser, FirstSelection = userMatch } ;
                currentUser.Matches.Add(newUserMatch);
            }
            var state = MatchmakingContext.SaveChanges();
            return state == 1 ? true : false;

        }
    }
}