using DementiaProject_Two.Models.Account;
using DementiaProject_Two.Models.Matching;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public static async Task<UserInformationModel> GetMatch(Guid userId)
        {
            ConfigureClient();
            UserInformationModel user = null;
            HttpResponseMessage response = await client.GetAsync(@"api/match/updateThis");
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
