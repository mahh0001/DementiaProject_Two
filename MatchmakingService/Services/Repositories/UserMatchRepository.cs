using MatchmakingService.DataContext;
using MatchmakingService.Helpers;
using MatchmakingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchmakingService.Services.Repositories
{
    // Update the fucking interface!!!
    public class UserMatchRepository : Repository<UserMatch>, IUserMatchRepository
    {
        public UserMatchRepository(MatchmakingContext matchmakingContext) : base(matchmakingContext)
        {

        }

        public MatchmakingContext MatchmakingContext
        {
            get
            {
                return base.Context as MatchmakingContext;
            }
        }

        // Skroll first through
        public UserMatch GetMatch(Guid userId)
        {
            var user = MatchmakingContext.UserInfos.First(x => x.IdentityFK == userId);

            // sees if someone has "matched" you and you have yet to respond
            var test = MatchmakingContext.Matches.Where(x => x.User2Id == userId && x.FirstSelection == true);



            var potentialMatch = MatchmakingContext.UserInfos
                            .Join(MatchmakingContext.Matches,
                            usr => usr.IdentityFK,
                            match => match.User1Id,
                            (usr, match) => new { UserInfo = usr, UserMatch = match })
                            .Where(x => x.UserInfo.IdentityFK != userId)
                            .Where(x => x.UserMatch.User2Id == userId && x.UserMatch.FirstSelection == true);
                            
                            //.Where(x => x.UserInfo.Matches != null).Where(x => x.UserMatch.User2Id == userId);

            

























            //UserInfo user = MatchmakingContext.UserInfos.First(x => x.IdentityFK == userId);
            //List<UserInfo> potentialMatchUsers = MatchmakingContext.UserInfos.ToList();
            //potentialMatchUsers.Remove(user);
            // this list will contain all users that you have not matched with excluding yourself
            //List<UserMatch> potentialMatches = MatchmakingHelpers.RemoveMatchDuplicates(potentialMatchUsers, user.Matches);

            //UserInfo otherUser = null;
            //UserMatch potentialMatch = null;
            //int numOfUsers = potentialMatches.Count();

            //for (int i = 0; i < numOfUsers; i++)
            //{
            //    potentialMatch = potentialMatches[i];





            //    // Redo all below here. Go over code!
            //    //otherUser = potentialMatches[i]);
            //    //if(otherUser.IdentityFK == userId)
            //    //{
            //    //    i++;
            //    //    otherUser = MatchmakingContext.UserInfos.ElementAt(i);
            //    //}



            //    //potentialMatch = MatchmakingContext.Matches[i]
            //    //potentialMatch = MatchmakingContext.Matches.FirstOrDefault(x => ((x.User2Id == otherUser.IdentityFK &&
            //    //                                                    x.User1Id == u1Id &&
            //    //                                                    x.User2Match == true &&
            //    //                                                    x.User1Match == null)) ||
            //    //                                                   (x.User1Id == otherUser.IdentityFK &&
            //    //                                                    x.User2Id == u1Id &&
            //    //                                                    x.User1Match == true &&
            //    //                                                    x.User2Match == null));
            //    if (potentialMatch != null)
            //    {
            //        return potentialMatch;
            //    }
            //}
            //  }

            //    public UserMatch GetMatch(Guid u1Id)
            //    {
            //        int numOfUsers = MatchmakingContext.UserInfos.Count();
            //        // other user has agreed to match or hasnt seen
            //        UserInfo otherUser = null;
            //        UserMatch potentialMatch = null;

            //        for (int i = 0; i < numOfUsers; i++)
            //        {
            //            otherUser = MatchmakingContext.UserInfos.FirstOrDefault(x => x.IdentityFK != u1Id);

            //            potentialMatch = MatchmakingContext.Matches.FirstOrDefault(x => ((x.User2Id == otherUser.IdentityFK &&
            //                                                                x.User1Id == u1Id &&
            //                                                                x.User2Match == true &&
            //                                                                x.User1Match == null)) ||
            //                                                               (x.User1Id == otherUser.IdentityFK &&
            //                                                                x.User2Id == u1Id &&
            //                                                                x.User1Match == true &&
            //                                                                x.User2Match == null));
            //            if(potentialMatch != null)
            //            {
            //                return potentialMatch;
            //            }
            //        }
            //        return new UserMatch();
            //    }
            //}
        }
    }