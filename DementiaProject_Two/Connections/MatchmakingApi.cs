using DementiaProject_Two.Models.Account;
using DementiaProject_Two.Models.DataTransferObjects;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DementiaProject_Two.Connections
{
    public static class MatchmakingApi
    {
        static HttpClient client;

        private static void ConfigureClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:5050/");
        }

        public static async Task<bool> CreateUserInformation(Guid userId)
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

        public static async Task AddToUserInformation(UserInfoDTO userInfo)
        {
            ConfigureClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(@"api/user/addinfo", userInfo);
            try
            {
                response.EnsureSuccessStatusCode();
                // might wanna add a bool rsum to be sure everything went smooth
            }
            catch(Exception ex)
            {

            }
        }

        public static async Task UpdateUserInformation(UserInfoDTO userInfo)
        {
            ConfigureClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(@"api/user/updateuser", userInfo);
            try
            {
                response.EnsureSuccessStatusCode();
                // might wanna add a bool rsum to be sure everything went smooth
            }
            catch (Exception ex)
            {

            }
        }

        public static async Task<UserInfoDTO> GetUserInformation(Guid userId)
        {
            ConfigureClient();
            UserInfoDTO userInfo = null;
            HttpResponseMessage response = await client.PostAsJsonAsync(@"api/user/getuser", userId);
            try
            {
                response.EnsureSuccessStatusCode();
                userInfo = await response.Content.ReadAsAsync<UserInfoDTO>();
            }
            catch(Exception ex)
            {

            }
            return userInfo;

        }

        public static async Task<UserInfoDTO> GetMatch(Guid userId)
        {
            ConfigureClient();
            UserInfoDTO user = null;
            HttpResponseMessage response = await client.PostAsJsonAsync(@"api/match/getmatch", userId);
            try
            {
                response.EnsureSuccessStatusCode();
                user = await response.Content.ReadAsAsync<UserInfoDTO>();
            }
            catch (Exception ex)
            {

            }
            return user;
        }

        public static async Task<bool> SaveMatchSelection(Guid currentUser, Guid otherUser, bool match)
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
