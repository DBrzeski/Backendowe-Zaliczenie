using Doggo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doggo.Services.IServices
{
    public interface IItemService
    {
        Task<T> GetAllItemsAsync<T>();
        Task<T> GetAItemByIdAsync<T>(int id);
        Task<T> CreateItemAsnyc<T>(Item item);
        Task<T> UpdateItemAsnyc<T>(Item item);
        Task<T> DeleteItemAsnyc<T>(int id);

    }
}
