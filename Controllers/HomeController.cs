using bArt_Test_task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace bArt_Test_task.Controllers
{
    public class HomeController : Controller
    {
        private IMemoryCache cache;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,IMemoryCache memory)
        {
            cache = memory;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var mem=cache.Get(1);
            if (mem == null)
            {
                cache.Set(1, mem);
                return View();
            }
            
            return View();
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
    }
}
