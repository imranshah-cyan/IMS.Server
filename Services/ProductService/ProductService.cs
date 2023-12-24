using IMSSPM.Data;

namespace IMSSPM.Services.ProductService
{
    public class ProductService : IProductService
    {

        private readonly DataContext _DBAccess;

        public ProductService(DataContext context)
        {
            _DBAccess = context;
        }
        public async Task<Product> AddProduct(Product product)
        {
            _DBAccess.Products.Add(product);
            await _DBAccess.SaveChangesAsync();

            return product;
        }

        public async Task<Product?> DeleteProduct(int id)
        {
            var result = await _DBAccess.Products.FindAsync(id);
            if (result == null)
                return null;

            _DBAccess.Products.Remove(result);
            await _DBAccess.SaveChangesAsync();
            return result;
        }

        public async Task<Product?> GetProduct(int id)
        {
            var result = await _DBAccess.Products.FindAsync(id);
            if (result == null)
                return null;

            return result;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _DBAccess.Products.ToListAsync();
        }

        public async Task<Product?> UpdateProduct(Product product)
        {
            var result = await _DBAccess.Products.FindAsync(product.ID);
            if (result == null)
                return null;

            result.Name = product.Name;
            result.Description = product.Description;
            result.Quantity = product.Quantity;

            await _DBAccess.SaveChangesAsync();

            return await _DBAccess.Products.FindAsync(product.ID);
        }
    }
}
