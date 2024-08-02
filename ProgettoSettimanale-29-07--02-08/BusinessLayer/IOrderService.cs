using ProgettoSettimanale_29_07__02_08.DataLayer.Entities;

namespace ProgettoSettimanale_29_07__02_08.BusinessLayer
{
    public interface IOrderService
    {
        Task <List<Order>>GetAllOrdersAsync();
        Task MarkAsDoneAsync(int id);
        Task<(int totalOrders, decimal totalIncome)> GetReportAsync(DateTime date);
    }
}
