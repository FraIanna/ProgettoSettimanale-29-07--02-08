using Microsoft.EntityFrameworkCore;
using ProgettoSettimanale_29_07__02_08.Context;
using ProgettoSettimanale_29_07__02_08.DataLayer.Entities;

namespace ProgettoSettimanale_29_07__02_08.BusinessLayer
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;

        public ProductService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateProductAsync(Product product, List<int> ingredientIds)
        {
            if (product.Ingredients == null)
            {
                product.Ingredients = new List<Ingredient>();
            }

            foreach (var ingredientId in ingredientIds)
            {
                var ingredient = await _dataContext.Ingredients.FindAsync(ingredientId);
                if (ingredient != null)
                {
                    product.Ingredients.Add(ingredient);
                }
            }

            _dataContext.Add(product);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _dataContext.Products.FindAsync(id);
            if (product != null)
            {
                _dataContext.Products.Remove(product);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _dataContext.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _dataContext.Products.FindAsync(id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            _dataContext.Update(product);
            await _dataContext.SaveChangesAsync();
        }

        public bool ProductExists(int id)
        {
            return _dataContext.Products.Any(e => e.Id == id);
        }
    }
}
