using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace checkerApplication
{
    public class CheckerHttpClient
    {

        private HttpRequestMessage request;
        private HttpClient client;
        public CheckerHttpClient(String url)
        {
            /*request = new HttpRequestMessage();
            request.RequestUri = new Uri(url);
            request.Method=HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");*/
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
        }

            // returns the content of the response as a string
            public async Task<String> SendRequest(string url)
            {
            return await client.GetStringAsync(url);
            }
        }
   
}
