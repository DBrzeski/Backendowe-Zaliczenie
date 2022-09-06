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

        public async Task<bool> DeleteItem(int itemId)
        {
            try
            {
                Item item = await _appdb.Item.FirstOrDefaultAsync(y => y.Id == itemId);
                if(item == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
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

        public async Task<ProductDto> UpdateItem(ProductDto productDto)
        {
            Item item = _mapper.Map<ProductDto, Item>(productDto);
            if(item.Id > 0)
            {
                _appdb.Item.Update(item);
            }
            else
            {
                _appdb.Item.Add(item);
            }
            await _appdb.SaveChangesAsync();
            return _mapper.Map<Item, ProductDto>(item);
        }
    }
}
