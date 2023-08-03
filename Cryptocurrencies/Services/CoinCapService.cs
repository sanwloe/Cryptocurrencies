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
        public async Task<CryptoCurrencyCoinCap[]> GetCryptoCurrencies()
        {
            return await _coinCapService.GetCryptoCurrencies();
        }
    }
}
