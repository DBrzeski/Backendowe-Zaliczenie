﻿using Doggo.ProductAPI.Models.Dto;
using Doggo.ProductAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doggo.ProductAPI.Controllers
{
    [Route("api/products")]
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
                IEnumerable<ProductDto> itemDTOs = await _repository.GetItems();
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
                ProductDto itemDTOs = await _repository.GetItemById(id);
                _response.Result = itemDTOs;
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