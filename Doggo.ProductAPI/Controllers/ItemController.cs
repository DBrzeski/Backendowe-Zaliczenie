using Doggo.ProductAPI.Models.Dto;
using Doggo.ProductAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doggo.ProductAPI.Controllers
{
    [Route("api/items")]
    public class ItemController : ControllerBase
    {
        protected ResponseDTO _response;
        private IItemRepository _repository;

        public ItemController(IItemRepository repository)
        {
            _repository = repository;
            this._response = new ResponseDTO();
        }
        [HttpGet]
        public async Task<Object> Get()
        {
            try
            {
                IEnumerable<ItemDto> itemDTOs = await _repository.GetItems();
                _response.Result = itemDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Object> Get(int id)
        {
            try
            {
                ItemDto itemDTOs = await _repository.GetItemById(id);
                _response.Result = itemDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        
        [HttpPost]
        [Authorize]
        public async Task<Object> Post([FromBody] ItemDto product)
        {
            try
            {
                ItemDto model = await _repository.UpdateItem(product);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        
        [HttpPut]
        [Authorize]
        public async Task<Object> Put([FromBody] ItemDto product)
        {
            try
            {
                ItemDto model = await _repository.UpdateItem(product);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        //[Authorize(Roles = "Admin")]
        [Route("{id}")]
        public async Task<Object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _repository.DeleteItem(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
