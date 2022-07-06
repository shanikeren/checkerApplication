using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using checkerApplication.Models;
using System.Net.Http;

namespace checkerApplication.Services

{
    public class LineDataStore : IDataStore<Line>
    {
        private readonly string extentionUri;

        public LineDataStore()
        {
            this.extentionUri = "/lines";
        }

        public async Task<bool> AddItemAsync(Line item)
        {
            try
            {
                var itemInJson = JsonSerializer.Serialize(item);
                var input = new StringContent(itemInJson, Encoding.UTF8, "application/json");
                var res = await App.client.PostAsync(extentionUri, input);
                if (res != null)
                {
                       var jsonString = await res.Content.ReadAsStringAsync();
                       App.restaurant.lines.Add(System.Text.Json.JsonSerializer.Deserialize<Line>(jsonString));
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

        public Task<Dish> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Line>> GetItemsAsync(bool forceRefresh = false)
        {
            string res = App.client.GetStringAsync(extentionUri).Result;
            List<Line> listy = JsonSerializer.Deserialize<List<Line>>(res);
            return listy;
        }

        public Task<bool> UpdateItemAsync(Dish item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Line item)
        {
            throw new NotImplementedException();
        }

        Task<Line> IDataStore<Line>.GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
       
}
