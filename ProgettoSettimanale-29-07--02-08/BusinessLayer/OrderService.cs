using Microsoft.EntityFrameworkCore;
using ProgettoSettimanale_29_07__02_08.Context;
using ProgettoSettimanale_29_07__02_08.DataLayer.Entities;

namespace ProgettoSettimanale_29_07__02_08.BusinessLayer
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _dataContext;

        public OrderService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _dataContext.Orders
                           .Include(o => o.User)
                           .Include(o => o.Items)
                           .ThenInclude(i => i.Product)
                           .ToListAsync();
        }

        public async Task<(int totalOrders, decimal totalIncome)> GetReportAsync(DateTime date)
        {
            var orders = await _dataContext.Orders
                           .Where(o => o.PlacedAt.Date == date && o.Done)
                           .Include(o => o.Items)
                           .ToListAsync();

            var totalOrders = orders.Count;
            var totalIncome = orders.Sum(o => o.Items.Sum(i => i.Product.Price * i.Quantity));

            return (totalOrders, totalIncome);
        }

        public async Task MarkAsDoneAsync(int id)
        {
            var order = await _dataContext.Orders.FindAsync(id);
            if (order != null)
            {
                order.Done = true;
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
