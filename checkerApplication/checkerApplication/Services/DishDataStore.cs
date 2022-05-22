using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using checkerApplication.Models;
using System.Net.Http;

namespace checkerApplication.Services
{
    public class DishDataStore : IDataStore<Dish>
    {
        private readonly string extentionUri;

        public DishDataStore()
        {
            this.extentionUri = "/dishes";
        }

        public Task<bool> AddItemAsync(Dish item)
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

        public async Task<IEnumerable<Dish>> GetItemsAsync(bool forceRefresh = false)
        {
            string res = App.client.GetStringAsync(extentionUri).Result;
            List<Dish> listy = JsonSerializer.Deserialize<List<Dish>>(res);
            return listy;
        }

        public Task<bool> UpdateItemAsync(Dish item)
        {
            throw new NotImplementedException();
        }
    }
}
