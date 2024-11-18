using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Entities;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Catalog.Repositories
{
    
    public class InMemItemsRepository:IItemsRepository
    {
        private readonly List<Item> items= new(){
            new Item{Id=Guid.NewGuid(),Name="Potion",Price = 9,CreatedDate=DateTimeOffset.UtcNow},
            new Item{Id=Guid.NewGuid(),Name="Iron Sword",Price = 20, CreatedDate=DateTimeOffset.UtcNow},
            new Item{Id=Guid.NewGuid(),Name="Bronze Shield", Price =18,CreatedDate=DateTimeOffset.UtcNow}
        };  

        public async Task<IEnumerable<Item>> GetItemsAsync(){
            return await Task.FromResult(items);
        }

        public async Task<Item> GetItemAsync(Guid id){
            var item= items.Where(x => x.Id == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        public async Task CreateItemAsync(Item item)
        {
            items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            var index = items.FindIndex(i=>i.Id == item.Id);
            items[index] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var index = items.FindIndex(i=>i.Id == id);
            items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }

}

