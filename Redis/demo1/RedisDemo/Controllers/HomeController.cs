using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RedisDemo.Models;
using ServiceStack.Redis;
using StackExchange.Redis;
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
        private readonly ConnectionMultiplexer _redisClientsManager;
        public HomeController(ILogger<HomeController> logger, ConnectionMultiplexer redisClientsManager)
        {
            _logger = logger;
            _redisClientsManager = redisClientsManager;
        }

        public IActionResult Index()
        {
            List<DateTime> dateTimes = new List<DateTime>();
          var date1  =DateTime.Now.AddMinutes(10);

            var test = insert();
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

        public int insert()
        {
            var result = _redisClientsManager.GetDatabase(1).StringIncrement("key1");
            if (result == 1)
            {
                _redisClientsManager.GetDatabase(1).KeyExpire("key1", TimeSpan.FromSeconds(30));
            }
            return (int)result;
         

           // redis.Add("demo", "sdfsdf");expiration
        }
    }
}
