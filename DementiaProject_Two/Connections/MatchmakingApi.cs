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
            client.BaseAddress = new Uri(@"http://localhost:57731/");
        }

        public static async Task<object> GetAuctionItems(Guid userId)
        {
            ConfigureClient();
            List<object> items = null;
            HttpResponseMessage response = await client.GetAsync(@"api/match/updateThis");
            try
            {
                response.EnsureSuccessStatusCode();
                items = await response.Content.ReadAsAsync<List<AuctionItem>>();
            }
            catch (Exception ex)
            {

            }
            return items;
        }



    }
}
