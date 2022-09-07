using Doggo.Services.IServices;
using Doggo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Doggo.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _service;
        public ItemController(IItemService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            List<ItemDto> list = new();
            var response = await _service.GetAllItemsAsync<ResponseDTO>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ItemDto>>(Convert.ToString(response.Result));
            }

            return View(list);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ItemDto model)
        {
            if (ModelState.IsValid)
            {
                List<ItemDto> list = new();
                var response = await _service.CreateItemAsnyc<ResponseDTO>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);

        }
        public async Task<IActionResult> Edit(int id)
        {
            if (ModelState.IsValid)
            {
                
                var response = await _service.GetAItemByIdAsync<ResponseDTO>(id);
                if (response != null && response.IsSuccess)
                {
                    ItemDto model = JsonConvert.DeserializeObject<ItemDto>(Convert.ToString(response.Result));
                    return View(model);
                }
            }
            return NotFound();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ItemDto model)
        {
            if (ModelState.IsValid)
            {
                List<ItemDto> list = new();
                var response = await _service.UpdateItemAsnyc<ResponseDTO>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);

        }
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {

                var response = await _service.GetAItemByIdAsync<ResponseDTO>(id);
                if (response != null && response.IsSuccess)
                {
                    ItemDto model = JsonConvert.DeserializeObject<ItemDto>(Convert.ToString(response.Result));
                    return View(model);
                }
            }
            return NotFound();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ItemDto model)
        {
            if (ModelState.IsValid)
            {
                List<ItemDto> list = new();
                var response = await _service.DeleteItemAsnyc<ResponseDTO>(model.Id);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);

        }
    }
}
