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
    public class RestMenuDataStore : IDataStore<RestMenu>
    {
        private readonly string extentionUri;

        public RestMenuDataStore()
        {
            this.extentionUri = "/menus";
        }
        public async Task<bool> AddItemAsync(RestMenu item)
        {
            try
            {
                var itemInJson = JsonConvert.SerializeObject(item);
                var input = new StringContent(itemInJson, Encoding.UTF8, "application/json");
                var res = await App.client.PostAsync(extentionUri, input);
                if (res != null)
                {
                    var jsonString = await res.Content.ReadAsStringAsync();
                    App.restaurant.menus.Add(System.Text.Json.JsonSerializer.Deserialize<RestMenu>(jsonString));
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }           
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
            List<RestMenu> listy = System.Text.Json.JsonSerializer.Deserialize<List<RestMenu>>(res);
            return listy;
        }

        public Task<bool> UpdateItemAsync(RestMenu item)
        {
            throw new NotImplementedException();
        }
    }
}
