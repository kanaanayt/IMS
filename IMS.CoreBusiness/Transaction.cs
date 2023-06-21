using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness
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
    public class Transaction
    {

        public int TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public ItemType ItemType { get; set; }
        public int QuantityBefore { get; set; }
        public int QuantityAfter { get; set; }
        public string PoNumber { get; set; } = String.Empty;
        public string Author { get; set; } = String.Empty;
        public DateTime TransactionDate { get; set; }
    }
}