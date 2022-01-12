using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Models
{
    public class ConversionModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public float Amount { get; set; }
    }
}
