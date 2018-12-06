using MatchmakingService.DataContext;
using MatchmakingService.Models;
using MatchmakingService.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchmakingService.Services.Repositories
{
    public class UserInfoRepository : Repository<UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(MatchmakingContext matchmakingContext) : base(matchmakingContext)
        {

        }

        public MatchmakingContext MatchmakingContext
        {
            get
            {
                return base.Context as MatchmakingContext;
            }
        }

        public void SaveChanges()
        {
            MatchmakingContext.SaveChanges();
        }

        public UserInfo GetInfoWithGuid(Guid id)
        {
            return MatchmakingContext.UserInfos.FirstOrDefault(x => x.IdentityFK == id);
        }

        public void AddUserInfo(UserInfoDTO userInfo) // this method can also be used to update the user...find a good name
        {
            var user = MatchmakingContext.UserInfos.First(x => x.IdentityFK == userInfo.IdentityFK);

            // couldn't we do this with mapping instead ?
            user.FirstName = userInfo.FirstName;
            user.LastName = userInfo.LastName;
            user.Age = userInfo.Age;
            user.ZipCode = userInfo.ZipCode;
            user.Gender = userInfo.Gender;
            user.Picture = userInfo.Picture;

            MatchmakingContext.UserInfos.Update(user);
            SaveChanges();
        }
    }
}
