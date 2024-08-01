using ProgettoSettimanale_29_07__02_08.DataLayer.Entities;

namespace ProgettoSettimanale_29_07__02_08.BusinessLayer
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task CreateProductAsync(Product product, List<int> ingredientIds);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        bool ProductExists(int id);
    }
}
