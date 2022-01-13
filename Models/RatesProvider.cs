using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyConverter.Models
{
    public class RatesProvider : IRatesProvider
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration config;

        public RatesProvider(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }
        public Dictionary<string, float> Rates { get; set; } = new Dictionary<string, float>();

        public async Task GetRatesAsync()
        {
            var client = httpClientFactory.CreateClient();

            var baseUrl = "http://api.exchangeratesapi.io/v1/latest";
            var apiKey = config.GetValue<string>("ApiKey");
            var url = $"{baseUrl}?&access_key={apiKey}";

            var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, url));
            var contentString = await response.Content.ReadAsStringAsync();

            var ratesString = contentString.Substring(contentString.LastIndexOf('{'));
            var rates = ratesString.Remove(ratesString.Length - 1);

            var ratesDict = JsonConvert.DeserializeObject<Dictionary<string, float>>(rates);

            foreach(var kvp in ratesDict)
            {
                Rates.Add(kvp.Key, kvp.Value);
            }
            
        }
    }
}
