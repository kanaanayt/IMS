using IMS.CoreBusiness;

namespace IMS.Services.Products.Interfaces
{
    public interface IViewProductsByNameService
    {
        Task<IEnumerable<Product>> ExecuteAsync(string searchTerm);
    }
}