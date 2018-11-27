using MatchmakingService.Models;
using System;

namespace MatchmakingService.Services.Repositories
{
    public interface IUserInfoRepository : IRepository<UserInfo>
    {
        UserInfo GetInfoWithGuid(Guid id);
    }
}