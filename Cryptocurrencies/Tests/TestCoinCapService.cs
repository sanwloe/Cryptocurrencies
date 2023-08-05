using Cryptocurrencies.Interfaces;
using Cryptocurrencies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.Tests
{
    public class TestCoinCapService : ICoinCapService
    {
        public async Task<CryptocurrencyCoinCap[]> GetCryptocurrenciesAsync()
        {
            return await Task.Run(() =>
            {
                return new CryptocurrencyCoinCap[]
                {
                    new CryptocurrencyCoinCap
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
                new CryptocurrencyCoinCap
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
                new CryptocurrencyCoinCap
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
            });
        }

        public async Task<InfoCryptocurrencyCoinCap[]> GetInfoAboutCryptocurrencyAsync(string cryptocurrency, string? interval)
        {
            return await Task.Run(() =>
            {
                return new InfoCryptocurrencyCoinCap[]
                {
                    new InfoCryptocurrencyCoinCap
                    {
                        Date = DateTime.Now,
                        PriceUsd = 1000,
                        Time = 1
                    },
                    new InfoCryptocurrencyCoinCap
                    {
                        Date = DateTime.Now,
                        PriceUsd = 1000,
                        Time = 1
                    },
                    new InfoCryptocurrencyCoinCap
                    {
                        Date = DateTime.Now,
                        PriceUsd = 1000,
                        Time = 1
                    }
                };
            });
        }

        public async Task<CryptocurrencyExchangeCoinCap[]> GetMarketsAsync(string cryptocurrency)
        {
            return await Task.Run(() =>
            {
                return new CryptocurrencyExchangeCoinCap[]
                {
                    new CryptocurrencyExchangeCoinCap
                    {
                        BaseId = "1",
                        BaseSymbol = "btc",
                        ExchangeId = "1",
                        PriceUsd = 30000,
                        QuoteId = "1",
                        QuoteSymbol = "1",
                        VolumePercent = 1,
                        VolumeUsd24Hr = 100000000
                    },
                    new CryptocurrencyExchangeCoinCap
                    {
                        BaseId = "2",
                        BaseSymbol = "eth",
                        ExchangeId = "2",
                        PriceUsd = 3000,
                        QuoteId = "2",
                        QuoteSymbol = "2",
                        VolumePercent = 2,
                        VolumeUsd24Hr = 250000000
                    },
                    new CryptocurrencyExchangeCoinCap
                    {
                        BaseId = "3",
                        BaseSymbol = "doge",
                        ExchangeId = "3",
                        PriceUsd = 3,
                        QuoteId = "3",
                        QuoteSymbol = "3",
                        VolumePercent = 3,
                        VolumeUsd24Hr = 3550000000
                    }
                };
            });

        }
    }
}
