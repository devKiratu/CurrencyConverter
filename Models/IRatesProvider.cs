using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Models
{
    public interface IRatesProvider
    {
        Dictionary<string, float> Rates { get; set; }
        Task GetRatesAsync();
    }
}
