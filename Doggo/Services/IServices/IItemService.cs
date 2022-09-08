using Doggo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doggo.Services.IServices
{
    public interface IItemService : IBaseService
    {
        Task<T> GetAllItemsAsync<T>(string token);
        Task<T> GetAItemByIdAsync<T>(int id, string token);
        Task<T> CreateItemAsnyc<T>(ItemDto item, string token);
        Task<T> UpdateItemAsnyc<T>(ItemDto item, string token);
        Task<T> DeleteItemAsnyc<T>(int id, string token);

    }
}
