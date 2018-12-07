using MatchmakingService.Models;
using MatchmakingService.Models.DataTransferObjects;
using System;

namespace MatchmakingService.Services.Repositories
{
    public interface IUserInfoRepository : IRepository<UserInfo>
    {
        void SaveChanges();
        UserInfo GetInfoWithGuid(Guid id);                 
        void AddUserInfo(UserInfoDTO userInfo);
    }
}