using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Models
{
    public class TransactionModel : ConversionModel
    {
        public int Id { get; set; }
        public float Output { get; set; }
        public DateTimeOffset TransactedAt { get; set; }
    }
}
