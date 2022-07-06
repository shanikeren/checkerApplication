using checkerApplication.Models;
using System;
using System.Collections.Generic;
//using System.Net.Http;
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
            this.extentionUri = "/ServingAreas";
        }

        public async Task<bool> AddItemAsync(ServingArea item)
        {
            try
            {
                var itemInJson = JsonSerializer.Serialize(item);
                var input = new System.Net.Http.StringContent(itemInJson, Encoding.UTF8, "application/json");
                var res = await App.client.PostAsync(extentionUri, input);
                if (res != null)
                {
                    var jsonString = await res.Content.ReadAsStringAsync();
                    App.restaurant.servingAreas.Add(System.Text.Json.JsonSerializer.Deserialize<ServingArea>(jsonString));
                }
                return true;
            }
            catch (Exception ex)
            {
                App.restaurant.servingAreas.Clear();
                return false;
            }
         
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
