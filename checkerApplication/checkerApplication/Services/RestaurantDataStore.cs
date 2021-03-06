using checkerApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace checkerApplication.Services
{
    public class RestaurantDataStore : IDataStore<Restaurant>
    {
        private readonly string extentionUri;

        public RestaurantDataStore()
        {
            this.extentionUri = "/restaurants";

        }
        public async Task<bool> AddItemAsync(Restaurant item)
        {
            try
            {
                var itemInJson = JsonConvert.SerializeObject(item);
                var input = new StringContent(itemInJson, Encoding.UTF8, "application/json");
                var res = await App.client.PostAsync(extentionUri, input);
                if (res != null)
                {
                    var jsonString = await res.Content.ReadAsStringAsync();
                    App.restaurant = System.Text.Json.JsonSerializer.Deserialize<Restaurant>(jsonString);
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
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
            List<Restaurant> listy = System.Text.Json.JsonSerializer.Deserialize<List<Restaurant>>(res);
            return listy;
        }

        public Task<bool> UpdateItemAsync(Restaurant item)
        {
            throw new NotImplementedException();
        }
    }
}
