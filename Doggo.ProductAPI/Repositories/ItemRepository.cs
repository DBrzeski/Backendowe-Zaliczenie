using AutoMapper;
using Doggo.ProductAPI.DbContexts;
using Doggo.ProductAPI.Models;
using Doggo.ProductAPI.Models.Dto;
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

        public async Task<ItemDto> GetItemById(int itemId)
        {
            Item item = await _appdb.Item.Where( x => x.Id == itemId).FirstOrDefaultAsync();
            return _mapper.Map<ItemDto>(item);
        }

        public async Task<IEnumerable<ItemDto>> GetItems()
        {
            List <Item> items =  await _appdb.Item.ToListAsync();
            return _mapper.Map<List<ItemDto>>(items);
        }

        public async Task<ItemDto> UpdateItem(ItemDto productDto)
        {
            Item item = _mapper.Map<ItemDto, Item>(productDto);
            if(item.Id > 0)
            {
                _appdb.Item.Update(item);
            }
            else
            {
                _appdb.Item.Add(item);
            }
            await _appdb.SaveChangesAsync();
            return _mapper.Map<Item, ItemDto>(item);
        }
    }
}
