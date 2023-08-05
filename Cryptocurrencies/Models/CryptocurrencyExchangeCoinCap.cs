using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.Models
{
    public class CryptocurrencyExchangeCoinCap
    {
        public string ExchangeId { get; set; } = string.Empty;
        public string BaseId { get; set; } = string.Empty;
        public string QuoteId { get; set; } = string.Empty;
        public string BaseSymbol { get; set; } = string.Empty;
        public string QuoteSymbol { get; set; } = string.Empty;
        public double VolumeUsd24Hr { get; set; }
        public double PriceUsd { get; set; }
        public double VolumePercent { get; set; }
    }
}
