using Doggo.Models;
using Doggo.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Doggo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemService _itemService;


        public HomeController(ILogger<HomeController> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        public async Task<IActionResult> Index()
        {
            List<ItemDto> List = new();
            var response = await _itemService.GetAllItemsAsync<ResponseDTO>("");
            if(response !=null && response.IsSuccess)
            {
                List = JsonConvert.DeserializeObject<List<ItemDto>>(Convert.ToString(response.Result));
            }

            return View(List);
        }
        
        public async Task<IActionResult> Details(int id)
        {
            ItemDto model = new();
            var response = await _itemService.GetAItemByIdAsync<ResponseDTO>(id, "");
            if (response != null && response.IsSuccess)
            {
                model = JsonConvert.DeserializeObject<ItemDto>(Convert.ToString(response.Result));
            }
            return View(model);
        }



            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize]
        public async Task<IActionResult> Login()
        {
            
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Logout()
        {
            return SignOut("Cookies","oidc");
        }
    }
}
