using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgettoSettimanale_29_07__02_08.Context;
using ProgettoSettimanale_29_07__02_08.Models;
using System.Diagnostics;

namespace ProgettoSettimanale_29_07__02_08.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _dataContext;

        public HomeController(DataContext dataContext, ILogger<HomeController> logger)
        {
            _logger = logger;
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _dataContext.Products
                .Include(p => p.Ingredients)
                .ToListAsync()
                ;
            return View(products);
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
