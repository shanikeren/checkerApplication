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
            this.extentionUri = "/Lines";
        }

        public Task<bool> AddItemAsync(Dish item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddItemAsync(Line item)
        {
            throw new NotImplementedException();
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

        Task<IEnumerable<Line>> IDataStore<Line>.GetItemsAsync(bool forceRefresh)
        {
            throw new NotImplementedException();
        }
    }
}
