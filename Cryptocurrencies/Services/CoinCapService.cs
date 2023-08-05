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
            return await _coinCapService.GetCryptocurrencies();
        }
        public async Task<CryptocurrencyExchangeCoinCap[]> GetMarkets(string cryptocurrency)
        {
            return await _coinCapService.GetMarkets(cryptocurrency);
        }
        public async Task<InfoCryptocurrencyCoinCap[]> GetInfoCryptocurrency(string cryptocurrency,string? interval)
        {
            return await _coinCapService.GetInfoAboutCryptocurrency(cryptocurrency,interval);
        }
    }
}
