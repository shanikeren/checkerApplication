using checkerApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace checkerApplication.Services
{
    internal class RestMenuDataStore : IDataStore<RestMenu>
    {
        private readonly string extentionUri;

        public RestMenuDataStore()
        {
            this.extentionUri = "/retsmenu";
        }
        public Task<bool> AddItemAsync(RestMenu item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<RestMenu> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RestMenu>> GetItemsAsync(bool forceRefresh = false)
        {
            string res = App.client.GetStringAsync(extentionUri).Result;
            List<RestMenu> listy = JsonSerializer.Deserialize<List<RestMenu>>(res);
            return listy;
        }

        public Task<bool> UpdateItemAsync(RestMenu item)
        {
            throw new NotImplementedException();
        }
    }
}
