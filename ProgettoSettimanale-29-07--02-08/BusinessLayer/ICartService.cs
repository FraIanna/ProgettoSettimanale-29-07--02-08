using ProgettoSettimanale_29_07__02_08.DataLayer.Entities;
using System.Security.Claims;

namespace ProgettoSettimanale_29_07__02_08.BusinessLayer
{
    public interface ICartService
    {
        Task AddToCartAsync(int userId, int productId, int quantity);
        Task CompleteOrderAsync(int userId, Order orderDetails);
        Task<Order?> GetActiveOrderAsync(int userId);
        Task<Order?> GetOrderByIdAsync(int orderId, int userId);
        Task<User?> GetUserByIdAsync(int userId);
    }
}
