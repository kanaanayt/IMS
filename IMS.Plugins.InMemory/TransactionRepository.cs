using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.CoreBusiness;
using IMS.Services.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class TransactionRepository : ITransactionRepository
    {
        private List<Transaction> _transactions = new();

        public Task AddTransactionAsync(Transaction.TransactionType tranType,
                                   Transaction.ItemType itmType,
                                   int quantity,
                                   string poNumber,
                                   string Author)
        {
            var transaction = new Transaction
            {
                TransactionId = _transactions.Count + 1,
                transactionType = tranType,
                itemType = itmType,


            }
        }
    }
}
