using IMS.CoreBusiness;

namespace IMS.Plugins.InMemory
{
    public interface IInventoryTransactionRepository
    {
        Task PurchaseAsync(Inventory inventory, string poNumber, string author, int quantity);
    }
}