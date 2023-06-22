using IMS.CoreBusiness;

namespace IMS.Services.PluginInterfaces
{
    public interface IInventoryTransactionRepository
    {
        Task PurchaseAsync(Inventory inventory, int quantity, double price, string poNumber, string author);
    }
}