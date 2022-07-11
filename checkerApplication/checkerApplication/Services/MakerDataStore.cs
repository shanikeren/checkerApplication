using checkerApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace checkerApplication.Services
{
    public class MakerDataStore
    {

        private readonly string extentionUri;

        public MakerDataStore()
        {
            this.extentionUri = "/Makers";

        }
        public async Task<bool> AddItemAsync(Maker item)
        {
            try
            {
                var itemInJson = System.Text.Json.JsonSerializer.Serialize(item);
                var input = new StringContent(itemInJson, Encoding.UTF8, "application/json");
                var res = await App.client.PostAsync(extentionUri, input);
                if (res != null)
                {
                    var jsonString = await res.Content.ReadAsStringAsync();
                    App.restaurant.makers.Add(System.Text.Json.JsonSerializer.Deserialize<Maker>(jsonString));
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

        public Task<Restaurant> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Maker>> GetItemsAsync(bool forceRefresh = false)
        {
            string res = App.client.GetStringAsync(extentionUri).Result;
            List<Maker> listy = System.Text.Json.JsonSerializer.Deserialize<List<Maker>>(res);
            return listy;
        }

        public Task<bool> UpdateItemAsync(Maker item)
        {
            throw new NotImplementedException();
        }
    }
}

