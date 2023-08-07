using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Cryptocurrencies.Managers;
using Cryptocurrencies.Models;
using Cryptocurrencies.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cryptocurrencies.ViewModels
{
    public class CryptocurrenciesViewModel : INotifyPropertyChanged
    {
        public CryptocurrenciesViewModel() 
        { 
            Initialize();
        }
        public ICommand? ViewInfoCryptocurrency { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        private ObservableCollection<CryptocurrencyCoinCap> _coinCaps = new();
        public ObservableCollection<CryptocurrencyCoinCap> CoinCaps 
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
        private string _searchKey;
        public string SearchKey
        {
            get
            {
                return _searchKey;
            }
            set 
            {
                if(value == _searchKey) 
                {
                    _searchKey = value;
                }
                else if(value != null) 
                {
                    _searchKey = value;
                    var result = CoinCaps.OrderBy(x => x.Id.StartsWith(_searchKey)).Reverse();          
                    CoinCaps = new(result);
                }
            }
        }
        private async void Initialize()
        {
            ViewInfoCryptocurrency = new RelayCommand<CryptocurrencyCoinCap>(GoToDetailedInformationCryptocurrency);
            var service = new CoinCapService();;
            CoinCaps = new(await service.GetCryptoCurrenciesAsync());
        }
        private void GoToDetailedInformationCryptocurrency(CryptocurrencyCoinCap? coin)
        {
            if(coin != null) 
            {
                _ = new DetailedInformationCryptocurrencyViewModel(coin);
            }          
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }    
    }
}
