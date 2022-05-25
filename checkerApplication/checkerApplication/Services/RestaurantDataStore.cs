using checkerApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace checkerApplication.Services
{
    internal class RestaurantDataStore : IDataStore<Restaurant>
    {
        private readonly string extentionUri;

        public RestaurantDataStore()
        {
            this.extentionUri = "/restaurant";

        }
        public Task<bool> AddItemAsync(Restaurant item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Restaurant> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Restaurant>> GetItemsAsync(bool forceRefresh = false)
        {
            string res = App.client.GetStringAsync(extentionUri).Result;
            List<Restaurant> listy = JsonSerializer.Deserialize<List<Restaurant>>(res);
            return listy;
        }

        public Task<bool> UpdateItemAsync(Restaurant item)
        {
            throw new NotImplementedException();
        }
    }
}
