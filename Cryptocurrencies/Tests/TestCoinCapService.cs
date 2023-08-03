using Cryptocurrencies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.Tests
{
    public class TestCoinCapService
    {
        public CryptoCurrencyCoinCap[] GetCryptoCurrencies()
        {
            return new CryptoCurrencyCoinCap[]
            {
                new CryptoCurrencyCoinCap
                {
                    Id = "1",
                    ChangePercent24Hr = 1,
                    MarketCapUsd = 1,
                    MaxSupply = 10,
                    Name = "bitcoin",
                    PriceUsd = 30000,
                    Rank = 1,
                    Supply = 19,
                    Symbol = "BTC",
                    VolumeUsd24Hr = 100000,
                    VWap24Hr = 100
                },
                new CryptoCurrencyCoinCap
                {
                    Id = "2",
                    ChangePercent24Hr = 2,
                    MarketCapUsd = 2,
                    MaxSupply = 1000,
                    Name = "litecoin",
                    PriceUsd = 3000,
                    Rank = 2,
                    Supply = 1900,
                    Symbol = "LTC",
                    VolumeUsd24Hr = 100000,
                    VWap24Hr = 100
                },
                new CryptoCurrencyCoinCap
                {
                    Id = "3",
                    ChangePercent24Hr = -2,
                    MarketCapUsd = 3,
                    MaxSupply = 10,
                    Name = "dogecoin",
                    PriceUsd = 0.5,
                    Rank = 3,
                    Supply = 19,
                    Symbol = "DG",
                    VolumeUsd24Hr = 10000000,
                    VWap24Hr = 101
                }
            };
        }
    }
}
