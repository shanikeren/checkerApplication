using checkerApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace checkerApplication.Services
{
    public class ServingAreaDataStore : IDataStore<ServingArea>
    {
        private readonly string extentionUri;

        public ServingAreaDataStore()
        {
            this.extentionUri = "/servingarea";
        }

        public Task<bool> AddItemAsync(ServingArea item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ServingArea> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ServingArea>> GetItemsAsync(bool forceRefresh = false)
        {
            string res = App.client.GetStringAsync(extentionUri).Result;
            List<ServingArea> listy = JsonSerializer.Deserialize<List<ServingArea>>(res);
            return listy;
        }

        public Task<bool> UpdateItemAsync(ServingArea item)
        {
            throw new NotImplementedException();
        }
    }
}
