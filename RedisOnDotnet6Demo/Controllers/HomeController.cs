using Microsoft.AspNetCore.Mvc;
using RedisOnDotnet6Demo.Models;
using System.Diagnostics;
using Microsoft.Extensions.Caching.Distributed;
using RedisOnDotnet6Demo.Data;
using RedisOnDotnet6Demo.Helpers;

namespace RedisOnDotnet6Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;
        private IDistributedCache _cache;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository, IDistributedCache cache)
        {
            _logger = logger;
            _userRepository = userRepository;
            _cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            List<User>? users;
            string loadLocation;
            string isCacheData;
            string recordKey = $"Users_{DateTime.Now:yyyyMMdd_hhmm}";

            users = await _cache.GetRecordAsync<List<User>>(recordKey);

            if (users is null) // Data not available in the Cache
            {
                users = await _userRepository.GetUsersAsync();
                loadLocation = $"Loaded from DB at {DateTime.Now}";
                isCacheData = "text-danger";

                await _cache.SetRecordAsync(recordKey, users);
            }
            else // Data available in the Cache
            {
                loadLocation = $"Loaded from Cache at {DateTime.Now}";
                isCacheData = "text-success";
            }

            ViewData["Style"] = isCacheData;
            ViewData["Location"] = loadLocation;

            return View(users);
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