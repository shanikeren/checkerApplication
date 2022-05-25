using checkerApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace checkerApplication.Services
{
    internal class OrderItemDataStore : IDataStore<OrderItem>
    {

        private readonly string extentionUri;

        public OrderItemDataStore()
        {
            this.extentionUri = "/orderitem";
        }

        public Task<bool> AddItemAsync(OrderItem item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItem> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderItem>> GetItemsAsync(bool forceRefresh = false)
        {
            string res = App.client.GetStringAsync(extentionUri).Result;
            List<OrderItem> listy = JsonSerializer.Deserialize<List<OrderItem>>(res);
            return listy;
        }

        public Task<bool> UpdateItemAsync(OrderItem item)
        {
            throw new NotImplementedException();
        }
    }
}
