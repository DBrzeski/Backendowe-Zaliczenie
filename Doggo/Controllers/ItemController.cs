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
            List<Item> list = new();
            var response = await _service.GetAllItemsAsync<ResponseDTO>();
            if(response !=null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<Item>>(Convert.ToString(response.Result));
            }

            return View(list);
        }
    }
}
