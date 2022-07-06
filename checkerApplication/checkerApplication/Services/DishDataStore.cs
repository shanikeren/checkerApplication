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

        public async Task<bool> AddItemAsync(Dish item)
        {
            try
            {
                var itemInJson = JsonSerializer.Serialize(item);
                var input = new StringContent(itemInJson, Encoding.UTF8, "application/json");
                var res = await App.client.PostAsync(extentionUri, input);
                if (res != null)
                {
                    var jsonString = await res.Content.ReadAsStringAsync();
                    App.restaurant.menus[0].dishes.Add( System.Text.Json.JsonSerializer.Deserialize<Dish>(jsonString));
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
