using Cryptocurrencies.Interfaces;
using Cryptocurrencies.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Cryptocurrencies.Services
{
    public class CoinCapHttpService : ICoinCapService
    {
        public async Task<CryptocurrencyCoinCap[]> GetCryptocurrenciesAsync()
        {
            HttpClient client = new();
            var response = await client.GetAsync("https://api.coincap.io/v2/assets");
            var result = await GetData<CryptocurrencyCoinCap>(response);
            return result;
        }
        public async Task<InfoCryptocurrencyCoinCap[]> GetInfoAboutCryptocurrencyAsync(string cryptocurrency,string? interval)
        {
            HttpClient client = new();
            HttpResponseMessage response;
            if(string.IsNullOrEmpty(interval)) 
            {
                response = await client.GetAsync($"https://api.coincap.io/v2/assets/{cryptocurrency}/history?interval=d1");
            }
            else
            {
                response = await client.GetAsync($"https://api.coincap.io/v2/assets/{cryptocurrency}/history?interval={interval}");
            }
            var result = await GetData<InfoCryptocurrencyCoinCap>(response);
            return result;     
        }
        public async Task<CryptocurrencyExchangeCoinCap[]> GetMarketsAsync(string cryptocurrency)
        {
            HttpClient client = new();
            var response = await client.GetAsync($"https://api.coincap.io/v2/assets/{cryptocurrency}/markets");
            var result = await GetData<CryptocurrencyExchangeCoinCap>(response);
            return result;
        }
        private static async Task<T[]> GetData<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);
            JToken? token = json["data"];
            if (token != null)
            {
                return JsonConvert.DeserializeObject<T[]>(token.ToString(),
                   new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore}) ?? Array.Empty<T>();
            }
            else
            { 
                return Array.Empty<T>();
            } 
        }
    }
}
