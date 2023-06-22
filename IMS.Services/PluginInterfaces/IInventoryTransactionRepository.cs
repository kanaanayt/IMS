using IMS.CoreBusiness;

namespace IMS.Services.PluginInterfaces
{
    public interface IInventoryTransactionRepository
    {
        Task PurchaseAsync(Inventory inventory, string poNumber, string author, int quantity, double price);
    }
}