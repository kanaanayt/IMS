using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness
{
    public class Transaction
    {
        public enum TransactionType
        {
            Purchase,
            Sell
        }
        public enum ItemType
        {
            Inventory,
            Product
        }
        public int TransactionId { get; set; }
        public TransactionType transactionType { get; set; }
        public ItemType itemType { get; set; }
        public int QuantityBefore { get; set; }
        public int QuantityAfter { get; set; }
        public string poNumber { get; set; } = String.Empty;
        public string Author { get; set; } = String.Empty;
        public DateTime TransactionDate { get; set; }
    }
}