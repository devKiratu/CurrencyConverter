using CurrencyConverter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionsController : ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly MainDbContext dbContext;
        private readonly IRatesProvider ratesProvider;

        public ConversionsController(IHttpClientFactory httpClientFactory, MainDbContext dbContext, IRatesProvider ratesProvider )
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.ratesProvider = ratesProvider ?? throw new ArgumentNullException(nameof(ratesProvider));
        }

        [HttpPost]
        public async Task<IActionResult> ConvertAsync([FromBody] ConversionModel model)
        {
            var output = Convert(model.From, model.To, model.Amount);

            if(output == float.MinValue)
            {
                return BadRequest("Could not convert, please check your input and retry");
            }

            var transaction = new TransactionModel
            {
                From = model.From,
                To = model.To,
                Amount = model.Amount,
                Output = output,
                TransactedAt = DateTimeOffset.UtcNow
            };

            await dbContext.Transactions.AddAsync(transaction);
            await dbContext.SaveChangesAsync();

            return Ok(transaction);

        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory()
        {
            var transactions = await dbContext.Transactions.ToListAsync();

            if (transactions.Count == 0 )
            {
                return NotFound();
            }

            return Ok(transactions);
        }

        private float Convert(string from, string to, float amount)
        {
            var rates = ratesProvider.Rates;

            if(rates.TryGetValue(from, out float fromCurrency) && rates.TryGetValue(to, out float toCurrency))
            {
                var output = amount * (toCurrency / fromCurrency);
                return output;
            }

            return float.MinValue;
        }

        //private async Task<float> GetConversionRateAsync(string from, string to)
        //{
        //    float rate = 0;
        //    var baseUrl = "https://free.currconv.com/api/v7/convert";
        //    var query = $"q={from}_{to}&compact=ultra";
        //    var apiKey = "2ee795613f5a7be338c9";
        //    var url = $"{baseUrl}?{query}&apiKey={apiKey}";

        //    var client = httpClientFactory.CreateClient();
        //    HttpResponseMessage response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, url));

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var amount = await response.Content.ReadAsStringAsync();
        //        rate = float.Parse(amount.Substring(11, 9));

        //    }

        //    return rate;
        //}
    }
}
