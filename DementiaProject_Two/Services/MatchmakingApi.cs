using DementiaProject_Two.Models.Account;
using DementiaProject_Two.Models.DataTransferObjects;
using DementiaProject_Two.Models.User;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DementiaProject_Two.Services
{
    public class MatchmakingApi
    {
        private HttpClient client;

        // Using wonderfull generics <3
        public async Task<T> GetEntityAsync<T>(string url) where T : class
        {
            string json = string.Empty;
            client = new HttpClient();
            try
            {
                json = await client.GetStringAsync(url);
            }
            catch(Exception ex)
            {

            }
            
            return JsonConvert.DeserializeObject<T>(json);
        }

        private void ConfigureClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(@"https://localhost:44375");
        }


        public async Task<bool> DeleteUser(Guid userId)
        {
            ConfigureClient();
            bool deleteSucceded = false;
            HttpResponseMessage response = await client.DeleteAsync($@"api/user/delete/{userId}");
            try
            {
                response.EnsureSuccessStatusCode();
                deleteSucceded = await response.Content.ReadAsAsync<bool>();
            }
            catch (Exception ex)
            {
                
            }
            return deleteSucceded;
        }

        public async Task AddUserInformation(UserInfoDTO userInfo)
        {
            ConfigureClient();
            bool addSuccessful = false;
            HttpResponseMessage response = await client.PostAsJsonAsync($@"api/user/add/", userInfo);
            try
            {
                response.EnsureSuccessStatusCode();
                //addSuccessful = await response.Content.ReadAsAsync<bool>();
            }
            catch (Exception ex)
            {
                
            }
            //return addSuccessful;

        }

        public async Task<bool> UpdateUser(UserModel userModel)
        {
            ConfigureClient();
            var response = await client.PostAsJsonAsync($@"api/user/edit/{userModel.IdentityFK}", userModel);

            bool updateSucceeded = false;
            try
            {
                response.EnsureSuccessStatusCode();
                updateSucceeded = await response.Content.ReadAsAsync<bool>();
            }
            catch (Exception)
            {
                return updateSucceeded;
            }

            return updateSucceeded;
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
    }
}
