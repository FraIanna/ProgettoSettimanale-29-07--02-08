using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgettoSettimanale_29_07__02_08.Context;
using ProgettoSettimanale_29_07__02_08.DataLayer.Entities;
using System.Security.Claims;

namespace ProgettoSettimanale_29_07__02_08.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _dataContext;

        public CartController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        private async Task<User?> GetCurrentUserAsync()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdString))
            {
                return null;
            }
            int userId;
            if (!int.TryParse(userIdString, out userId))
            {
                return null;
            }
            return await _dataContext.Users.FindAsync(userId);
        }

        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var product = await _dataContext.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            var order = await _dataContext.Orders
                .Include(o => o.Items)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.User.Id == user.Id && !o.Done);

            if (order == null)
            {
                order = new Order
                {
                    User = user,
                    PlacedAt = DateTime.Now,
                    Address = "Inserisci Indirizzo",
                    Items = new List<OrderItem>()
                };
                _dataContext.Orders.Add(order);
            }

            var orderItem = order.Items.FirstOrDefault(oi => oi.Product.Id == productId);
            if (orderItem == null)
            {
                orderItem = new OrderItem
                {
                    Product = product,
                    Order = order,
                    Quantity = quantity
                };
                order.Items.Add(orderItem);
            }
            else
            {
                orderItem.Quantity += quantity;
            }

            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Cart()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var order = await _dataContext.Orders
                .Include(o => o.Items)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.User.Id == user.Id && !o.Done);

            if (order == null)
            {
                order = new Order
                {
                    User = user,
                    PlacedAt = DateTime.Now,
                    Address = "Inserisci Indirizzo",
                    Items = new List<OrderItem>()
                };
                _dataContext.Orders.Add(order);
                await _dataContext.SaveChangesAsync();
            }

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(Order orderDetails)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var order = await _dataContext.Orders
                .Include(o => o.Items)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.User.Id == user.Id && !o.Done);

            if (order == null)
            {
                return RedirectToAction("Cart");
            }

            order.Address = orderDetails.Address;
            order.Notes = orderDetails.Notes;
            order.Done = true;

            await _dataContext.SaveChangesAsync();

            return RedirectToAction("OrderConfirmation", new { orderId = order.Id });
        }

        public async Task<IActionResult> OrderConfirmation(int orderId)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var order = await _dataContext.Orders
                .Include(o => o.Items)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId && o.User.Id == user.Id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}
