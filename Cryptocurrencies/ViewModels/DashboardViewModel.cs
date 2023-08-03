using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit;
using Cryptocurrencies.Models;
using Cryptocurrencies.Services;

namespace Cryptocurrencies.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        public DashboardViewModel() 
        {
            Initialize();
        }
        private async void Initialize()
        {
            var service = new CoinCapService();
            var result = await service.GetCryptoCurrencies();
            CoinCaps = new ObservableCollection<CryptoCurrencyCoinCap>(result.Take(10));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private ObservableCollection<CryptoCurrencyCoinCap> _coinCaps = new();
        public ObservableCollection<CryptoCurrencyCoinCap> CoinCaps
        {
            get
            {
                if(!_coinCaps.Any())
                {
                    Initialize();
                    return _coinCaps;
                }
                else
                {
                    return _coinCaps;
                }
            }
            set
            {
                _coinCaps = value;
                OnPropertyChanged(nameof(CoinCaps));
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
