using AutoMapper;
using Doggo.ProductAPI.DbContexts;
using Doggo.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doggo.ProductAPI.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _appdb;
        private IMapper _mapper;

        public ItemRepository(AppDbContext appDb, IMapper mapper)
        {
            _appdb = appDb;
            _mapper = mapper;
        }

        public Task<bool> DeleteItem(int itemId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDto> GetItemById(int itemId)
        {
            Item item = await _appdb.Item.Where( x => x.Id == itemId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(item);
        }

        public async Task<IEnumerable<ProductDto>> GetItems()
        {
            List <Item> items =  await _appdb.Item.ToListAsync();
            return _mapper.Map<List<ProductDto>>(items);
        }

        public  Task<ProductDto> UpdateItem(ProductDto productDto)
        {
            throw new NotImplementedException();
        }
    }
}
