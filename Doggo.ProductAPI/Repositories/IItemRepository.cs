using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doggo.ProductAPI.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<ProductDto>> GetItems();
        Task<ProductDto> GetItemById(int itemId);
        Task<ProductDto> UpdateItem(ProductDto productDto);
        Task<bool> DeleteItem(int itemId);
    }
}
