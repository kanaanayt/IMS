using IMS.CoreBusiness;

namespace IMS.Services.Products.Interfaces
{
    public interface IEditProductItemService
    {
        Task ExecuteAsync(Product product);
    }
}