﻿using Doggo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doggo.Services.IServices
{
    public interface IItemService : IBaseService
    {
        Task<T> GetAllItemsAsync<T>();
        Task<T> GetAItemByIdAsync<T>(int id);
        Task<T> CreateItemAsnyc<T>(ItemDto item);
        Task<T> UpdateItemAsnyc<T>(ItemDto item);
        Task<T> DeleteItemAsnyc<T>(int id);

    }
}
