using IMS.CoreBusiness;

namespace IMS.Services.Products.Interfaces
{
    public interface IAddProductItemService
    {
        Task ExecuteAsync(Product product);
    }
}