using Doggo.ProductAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doggo.ProductAPI.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemDto>> GetItems();
        Task<ItemDto> GetItemById(int itemId);
        Task<ItemDto> UpdateItem(ItemDto productDto);
        Task<bool> DeleteItem(int itemId);
    }
}
