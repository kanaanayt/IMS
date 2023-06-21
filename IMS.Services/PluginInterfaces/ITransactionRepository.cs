using IMS.CoreBusiness;

namespace IMS.Services.PluginInterfaces
{
    public interface ITransactionRepository
    {
        Task AddTransactionAsync(Transaction.TransactionType transactionType, Transaction.ItemType itemType, int quantity, string poNumber, string Author);
    }
}