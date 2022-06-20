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
            var itemInJson = JsonConvert.SerializeObject(item);
            var input = new StringContent(itemInJson, Encoding.UTF8, "application/json");
            var res = await App.client.PostAsync(extentionUri, input);
            return res.Equals("1");
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

