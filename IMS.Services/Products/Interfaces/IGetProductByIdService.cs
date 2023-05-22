using IMS.CoreBusiness;

namespace IMS.Services.Products.Interfaces
{
    public interface IGetProductByIdService
    {
        Task<Product> ExecuteAsync(int productId);
    }
}