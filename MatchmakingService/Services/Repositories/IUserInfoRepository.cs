using MatchmakingService.Models;
using System;

namespace MatchmakingService.Services.Repositories
{
    public interface IUserInfoRepository : IRepository<UserInfo>
    {
        void SaveChanges();
        UserInfo GetInfoWithGuid(Guid id);
    }
}