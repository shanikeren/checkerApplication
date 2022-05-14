using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace checkerApplication
{
    internal class CheckerHttpClient
    {
        
            private readonly HttpClient checker;
            public CheckerHttpClient(String url)
            {
                checker = new HttpClient();
                checker.BaseAddress = new Uri(url);
                checker.Timeout = TimeSpan.FromMinutes(5);
            }

            // returns the content of the response as a string
            public async Task<String> SendRequest()
            {
                // get the content of the response
                return await checker.GetStringAsync("/restaurants");
            }
        }
   
}
