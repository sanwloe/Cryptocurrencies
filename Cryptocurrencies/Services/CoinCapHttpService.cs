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
        public async Task<CryptoCurrencyCoinCap[]> GetCryptoCurrencies()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://api.coincap.io/v2/assets");
            var result = await GetData<CryptoCurrencyCoinCap>(response);
            return result;
        }
        private async Task<T[]> GetData<T>(HttpResponseMessage response)
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
