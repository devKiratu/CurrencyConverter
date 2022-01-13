using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Models
{
    public static class RatesApi
    {
        public async static Task GetExchangeRates(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var provider = scope.ServiceProvider;
            var ratesProvider = provider.GetRequiredService<IRatesProvider>();
            await ratesProvider.GetRatesAsync();
        }
    }
}
