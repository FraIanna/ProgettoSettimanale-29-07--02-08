using ProgettoSettimanale_29_07__02_08.DataLayer.Entities;

namespace ProgettoSettimanale_29_07__02_08.BusinessLayer
{
    public class CartService : ICartService
    {
        public Task AddToCartAsync(int userId, int productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task CompleteOrderAsync(int userId, Order orderDetails)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> GetActiveOrderAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> GetOrderByIdAsync(int orderId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
