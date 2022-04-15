using Microsoft.AspNetCore.Mvc;
using RedisOnDotnet6Demo.Models;
using System.Diagnostics;
using RedisOnDotnet6Demo.Data;

namespace RedisOnDotnet6Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index(bool? fromCache)
        {
            List<User> users;
            if(fromCache == true){
                users = await _userRepository.GetUsersAsync();
            } else {
                users = await _userRepository.GetUsersAsync();
            }
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