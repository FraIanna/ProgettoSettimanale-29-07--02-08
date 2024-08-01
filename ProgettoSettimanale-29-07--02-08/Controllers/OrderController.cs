using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgettoSettimanale_29_07__02_08.Context;

namespace ProgettoSettimanale_29_07__02_08.Controllers
{
    public class OrderController : Controller
    {
        private readonly DataContext _dataContext;

        public OrderController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> AllOrders()
        {
            var orders = await _dataContext.Orders.Include(o => o.User).Include(o => o.Items).ThenInclude(i => i.Product).ToListAsync();
            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsDone(int id)
        {
            var order = await _dataContext.Orders.FindAsync(id);
            if (order != null)
            {
                order.Done = true;
                await _dataContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(AllOrders));
        }

        public async Task<IActionResult> Report()
        {
            var today = DateTime.Today;
            var orders = await _dataContext.Orders
                .Where(o => o.PlacedAt.Date == today && o.Done)
                .Include(o => o.Items)
                .ToListAsync();

            var totalOrders = orders.Count;
            var totalIncome = orders.Sum(o => o.Items.Sum(i => i.Product.Price * i.Quantity));

            return Json(new { totalOrders, totalIncome });
        }
    }
}
