using Cryptocurrencies.Models;
using Cryptocurrencies.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.ViewModels
{
    public class CryptocurrenciesViewModel : INotifyPropertyChanged
    {
        public CryptocurrenciesViewModel() 
        { 
            Initialize();
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
                }
                return _coinCaps;
            }
            set 
            {
                _coinCaps = value;
                OnPropertyChanged(nameof(CoinCaps));
            }
        }
        private async void Initialize()
        {
            var service = new CoinCapService();
            var result = await service.GetCryptoCurrenciesAsync();
            CoinCaps = new ObservableCollection<CryptoCurrencyCoinCap>(result);
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }    
    }
}
