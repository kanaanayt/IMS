using IMS.CoreBusiness;

namespace IMS.Services.Activities
{
    public interface IPurchaseInventoryService
    {
        Task ExecuteAsync(Inventory inventory, int purchaseQuantity, string author, string poNumber);
    }
}