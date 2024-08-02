using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgettoSettimanale_29_07__02_08.BusinessLayer;
using ProgettoSettimanale_29_07__02_08.Context;

namespace ProgettoSettimanale_29_07__02_08.Controllers
{
    [Authorize (Policies.isLoggedAdmin)]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> AllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsDone(int id)
        {
            await _orderService.MarkAsDoneAsync(id);
            return RedirectToAction(nameof(AllOrders));
        }

        public async Task<IActionResult> Report()
        {
            var today = DateTime.Today;
            var (totalOrders, totalIncome) = await _orderService.GetReportAsync(today);
            return Json(new { totalOrders, totalIncome });
        }
    }
}
