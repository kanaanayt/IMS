using IMS.CoreBusiness;

namespace IMS.Services.PluginInterfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsByNameAsync(string searchTerm);
        Task<Product> GetProductByIdAsync(int productId);
        Task EditProductItemAsync(Product product);
    }
}