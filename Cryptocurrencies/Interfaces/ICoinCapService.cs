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
        public Task<CryptocurrencyCoinCap[]> GetCryptocurrencies();
        public Task<CryptocurrencyExchangeCoinCap[]> GetMarkets(string cryptocurrency);
        public Task<InfoCryptocurrencyCoinCap[]> GetInfoAboutCryptocurrency(string cryptocurrency, string? interval);
    }
}
