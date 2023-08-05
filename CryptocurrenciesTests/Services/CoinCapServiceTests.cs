using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cryptocurrencies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptocurrencies.Tests;

namespace Cryptocurrencies.Services.Tests
{
    [TestClass()]
    public class CoinCapServiceTests
    {
        CoinCapService service;
        [TestInitialize]
        public void Initialize()
        {
            service = new CoinCapService(new TestCoinCapService());
        }
        [TestMethod()]
        public async Task GetCryptoCurrenciesAsyncTest()
        {
            var result = await service.GetCryptoCurrenciesAsync();
            int expected = 3;
            int actual = result.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public async Task GetMarketsTest()
        {
            var result = await service.GetMarketsAsync(string.Empty);
            int expected = 3;
            int actual = result.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public async Task GetInfoCryptocurrencyAsyncTest()
        {
            var result = await service.GetInfoCryptocurrencyAsync(string.Empty,null);
            int expected = 3;
            int actual = result.Length;
            Assert.AreEqual(expected, actual);
        }
    }
}