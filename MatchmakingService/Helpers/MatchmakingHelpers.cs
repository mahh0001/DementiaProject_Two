using MatchmakingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchmakingService.Helpers
{
    // This seriously needs to be tested!!!
    public static class MatchmakingHelpers
    {
        public static UserMatch[] RemoveMatchDuplicates(UserInfo[] potentialMatchUsers, UserMatch[] alreadyMatched)
        {
            HashSet<UserMatch> alreadySeen = new HashSet<UserMatch>();
            foreach (var item in potentialMatchUsers)
            {
                foreach (var match in item.Matches)
                {
                    if (!alreadySeen.Contains(match))
                    {
                        foreach (var haveMatched in alreadyMatched)
                        {
                            if (!alreadySeen.Contains(haveMatched))
                            {
                                alreadySeen.Add(match);
                            }
                        }

                    }
                }
            }   
            return alreadySeen.ToArray();
        }
    }
}
