using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public float Amount { get; set; }
        public float Output { get; set; }
        public DateTimeOffset TransactedAt { get; set; }
    }
}
