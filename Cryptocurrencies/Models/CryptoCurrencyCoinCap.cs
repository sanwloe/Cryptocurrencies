using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.Models
{
    public class CryptoCurrencyCoinCap
    {
        public string Id { get; set; } = string.Empty;
        public int Rank { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string Name { get; set;} = string.Empty;
        public double Supply { get; set; }
        public double MaxSupply { get; set; }
        public double MarketCapUsd { get; set; }
        public double VolumeUsd24Hr { get; set; }
        public double PriceUsd { get; set; }
        public double ChangePercent24Hr { get; set; }
        public double VWap24Hr { get; set; }
    }
}
