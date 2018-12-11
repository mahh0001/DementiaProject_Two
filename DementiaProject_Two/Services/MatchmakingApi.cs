using DementiaProject_Two.Models.Account;
using DementiaProject_Two.Models.DataTransferObjects;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DementiaProject_Two.Services
{
    public class MatchmakingApi
    {
        private HttpClient client;

        private void ConfigureClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:44375/");
        }

        public async Task<bool> CreateUserInformation(Guid userId)
        {
            ConfigureClient();
            bool success = false;
            HttpResponseMessage response = await client.PostAsJsonAsync(@"api/user/createuser", userId);
            try
            {
                response.EnsureSuccessStatusCode();
                success = true;
            }
            catch(Exception ex)
            {

            }
            return success;
        }

        public async Task AddToUserInformation(UserInfoDTO userInfo)
        {

        }

        public async Task<UserInformationModel> GetMatch(Guid userId)
        {
            ConfigureClient();
            UserInformationModel user = null;
            HttpResponseMessage response = await client.PostAsJsonAsync(@"api/match/getmatch", userId);
            try
            {
                response.EnsureSuccessStatusCode();
                user = await response.Content.ReadAsAsync<UserInformationModel>();
            }
            catch (Exception ex)
            {

            }
            return user;
        }

        public async Task<bool> SaveMatchSelection(Guid currentUser, Guid otherUser, bool match)
        {
            ConfigureClient();
            bool saveSucceeded = false;
            MatchDTO matchDto = new MatchDTO
            {
                User1 = currentUser,
                User2 = otherUser,
                Match = match
            };
            HttpResponseMessage response = await client.PostAsJsonAsync(@"api/match/savematch", matchDto);

            try
            {
                response.EnsureSuccessStatusCode();
                saveSucceeded = await response.Content.ReadAsAsync<bool>();
            }
            catch(Exception ex)
            {

            }
            return saveSucceeded;
        }

    }
}
