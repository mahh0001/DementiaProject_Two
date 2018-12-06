using MatchmakingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchmakingService.Services.Repositories
{
    public interface IUserMatchRepository : IRepository<UserMatch>
    {
        UserInfo FindRandomUser(Guid currentUser);
        bool SaveMatchChoice(Guid currentUser, Guid potentialMatchUser, bool match);
        //UserMatch GetMatch(Guid u1Id);
    }
}
