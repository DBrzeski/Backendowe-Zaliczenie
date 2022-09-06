using Doggo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Doggo.Services.IServices
{
    public class ItemService : BaseService, IItemService
    {
        private readonly IHttpClientFactory _clinetFactory;
        public ItemService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clinetFactory = clientFactory;
        }


        public async Task<T> CreateItemAsnyc<T>(ItemDto item)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = item,
                Url = SD.ItemAPIBase + "/api/items",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteItemAsnyc<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ItemAPIBase + "/api/items"+id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAItemByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ItemAPIBase + "/api/items"+id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllItemsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ItemAPIBase + "/api/items",
                AccessToken = ""
            });
        }

        public async Task<T> UpdateItemAsnyc<T>(ItemDto item)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = item,
                Url = SD.ItemAPIBase + "/api/items",
                AccessToken = ""
            });
        }
    }
}
