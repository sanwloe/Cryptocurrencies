using Cryptocurrencies.Interfaces;
using Cryptocurrencies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.Services
{
    public class CoinCapService
    {
        private readonly ICoinCapService _coinCapService;
        public CoinCapService(ICoinCapService coinCapService)
        {
            _coinCapService = coinCapService;
        }
        public CoinCapService()
        {
            _coinCapService = new CoinCapHttpService();
        }
        public async Task<CryptocurrencyCoinCap[]> GetCryptoCurrenciesAsync()
        {
            return await _coinCapService.GetCryptocurrenciesAsync();
        }
        public async Task<CryptocurrencyExchangeCoinCap[]> GetMarketsAsync(string cryptocurrency)
        {
            return await _coinCapService.GetMarketsAsync(cryptocurrency);
        }
        public async Task<InfoCryptocurrencyCoinCap[]> GetInfoCryptocurrencyAsync(string cryptocurrency,string? interval)
        {
            return await _coinCapService.GetInfoAboutCryptocurrencyAsync(cryptocurrency,interval);
        }
    }
}
