using CommunityToolkit.Mvvm.Input;
using Cryptocurrencies.Managers;
using Cryptocurrencies.Views;
using ModernWpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cryptocurrencies.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel() 
        {
            Initialize();
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand? ViewDashboard { get; set; }
        public ICommand? ChangeTheme { get; set; }
        public ICommand? ViewCryptocurrencies { get; set; }
        private void Initialize()
        {
            ViewDashboard = new RelayCommand(GoToDashboard);
            ChangeTheme = new RelayCommand(DoChangeTheme);
            ViewCryptocurrencies = new RelayCommand(GoToListCryptocurrencies);
            LoadTheme();
            
        }
        private void GoToDashboard()
        {
            ViewNewPage(new Dashboard());
        }
        private void GoToListCryptocurrencies()
        {
            ViewNewPage(new Views.Cryptocurrencies());
        }
        private void DoChangeTheme()
        {
            if (ThemeManager.Current.ActualApplicationTheme == ApplicationTheme.Dark)
            {
                ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
                MyThemeManager.SetLightTheme();
            }
            else
            {
                ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
                MyThemeManager.SetDarkTheme();
            }
        }
        private void LoadTheme()
        {
            if (ThemeManager.Current.ActualApplicationTheme == ApplicationTheme.Dark)
            {            
                MyThemeManager.SetDarkTheme();
            }
            else
            {
                ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
                MyThemeManager.SetLightTheme();
            }
        }
        private static bool CheckFrame(Object obj)
        {
            var window = ResourceManager.GetMainWindow();
            if(window.framecontent.Content.GetType().Equals(obj))
            {
                return true;
            }
            else 
            { 
                return false; 
            }           
        }
        private static void ViewNewPage(Page page)
        {
            var window = ResourceManager.GetMainWindow();
            if (!CheckFrame(page.GetType()))
            {
                window.framecontent.Content = page;
            }
        }
    }
}
