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
        private void Initialize()
        {
            ViewDashboard = new RelayCommand(GoToDashboard);
            ChangeTheme = new RelayCommand(DoChangeTheme);
        }
        private void GoToDashboard()
        {
            var window = ResourceManager.GetMainWindow();
            if(window.framecontent.Content as Dashboard == null) 
            {
                window.framecontent.Content = new Dashboard();
            }
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
                ModernWpf.ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
                MyThemeManager.SetDarkTheme();
            }
        }
    }
}
