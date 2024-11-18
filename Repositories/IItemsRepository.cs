using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entities;

namespace Catalog.Repositories{
    public interface IItemsRepository{
        Task<Item> GetItemAsync(Guid id);
        Task<IEnumerable<Item>> GetItemsAsync();

        Task CreateItemAsync(Item item);
        public Task UpdateItemAsync(Item item);
        public Task DeleteItemAsync(Guid id);
        
    }
}