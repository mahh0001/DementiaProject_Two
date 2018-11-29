using DementiaProject_Two.Models.Account;

namespace DementiaProject_Two.Repositories
{
    public interface IRepository
    {
        UserInformationModel Get(int id);
        UserInformationModel Update(UserInformationModel userInfo);
    }
}
