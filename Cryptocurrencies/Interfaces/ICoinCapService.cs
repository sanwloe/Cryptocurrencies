using Cryptocurrencies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.Interfaces
{
    public interface ICoinCapService
    {
        public Task<CryptocurrencyCoinCap[]> GetCryptocurrenciesAsync();
        public Task<CryptocurrencyExchangeCoinCap[]> GetMarketsAsync(string cryptocurrency);
        public Task<InfoCryptocurrencyCoinCap[]> GetInfoAboutCryptocurrencyAsync(string cryptocurrency, string? interval);
    }
}
