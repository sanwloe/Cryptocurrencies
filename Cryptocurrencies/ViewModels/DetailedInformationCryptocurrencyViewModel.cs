using Cryptocurrencies.Models;
using Cryptocurrencies.Services;
using LiveCharts.Defaults;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Cryptocurrencies.Managers;
using Cryptocurrencies.Views;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using System.Runtime.Serialization;

namespace Cryptocurrencies.ViewModels
{
    public class DetailedInformationCryptocurrencyViewModel : INotifyPropertyChanged
    {   
        public DetailedInformationCryptocurrencyViewModel() 
        {
            Coin = new();          
        }
        public DetailedInformationCryptocurrencyViewModel(CryptocurrencyCoinCap coin) 
        {
            Coin = coin;
            Initialize();
        }
        CryptocurrencyCoinCap Coin { get; }
        private ObservableCollection<CryptocurrencyExchangeCoinCap> _markets = new();
        public ObservableCollection<CryptocurrencyExchangeCoinCap> Markets
        {
            get
            {
                if(!_markets.Any())
                {
                    InitializeMarkets();
                }
                return _markets;        
            }
            set
            {
                _markets = value;
                OnPropertyChanged(nameof(Markets));
            }
        }
        private SeriesCollection _series = new();
        public SeriesCollection Series 
        { 
            get
            {
                if(!_series.Any())
                {
                    InitializeChart();
                }
                return _series;
            }
            set
            {
                _series = value;
                OnPropertyChanged(nameof(Series));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public Func<double, string>? StringFormatter { get; set; }

        private async void Initialize()
        {
            CoinCapService coinCapService = new();           
            Markets = new(await coinCapService.GetMarkets(Coin.Id));
            InitializeChart();
            InitializeMarkets();
            View();
        }
        private async void InitializeChart()
        {
            CoinCapService coinCapService = new();
            var info = (await coinCapService.GetInfoCryptocurrency(Coin.Id, "h12")).TakeLast(30);           
            var values = new ChartValues<DateTimePoint>();
            foreach (var item in info)
            {
                values.Add(new DateTimePoint(item.Date, item.PriceUsd));
            }
            Series = new SeriesCollection(Mappers.Xy<DateTimePoint>()
                .X(dayModel => (double)dayModel.DateTime.Ticks / TimeSpan.FromHours(1).Ticks)
                .Y(dayModel => dayModel.Value))
            {
                new LineSeries { Values = values }
            };
            StringFormatter = value => new DateTime((long)(value * TimeSpan.FromHours(1).Ticks)).ToString("G");
        }
        private async void InitializeMarkets()
        {
            CoinCapService coinCapService = new();
            Markets = new(await coinCapService.GetMarkets(Coin.Id));
        }
        private void View()
        {
            var page = new DetailedInformationCryptocurrency
            {
                DataContext = this
            };
            ResourceManager.ChangePage(page);
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
