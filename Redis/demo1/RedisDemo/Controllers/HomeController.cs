using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RedisDemo.Models;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RedisDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRedisClientsManager _redisClientsManager;
        public HomeController(ILogger<HomeController> logger, IRedisClientsManager redisClientsManager)
        {
            _logger = logger;
            _redisClientsManager = redisClientsManager;
        }

        public IActionResult Index()
        {
            insert();
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

        public void insert()
        {
           var redis=  _redisClientsManager.GetClient();
            redis.Add("demo", "sdfsdf");
        }
    }
}
