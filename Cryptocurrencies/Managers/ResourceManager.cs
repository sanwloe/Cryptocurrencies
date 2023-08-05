using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Cryptocurrencies.Managers
{
    public static class ResourceManager
    {
        public static MainWindow GetMainWindow()
        {
            return Application.Current.MainWindow as MainWindow;
        }
        public static void DeleteResource(string path)
        {
            var window = GetMainWindow();
            var resource = window.Resources.MergedDictionaries.FirstOrDefault(x => x.Source.ToString().StartsWith(path));
            if(resource != null) 
            {
                window.Resources.MergedDictionaries.Remove(resource);
            }
        }
        public static void AddResource(string path) 
        {
            var window = GetMainWindow();
            var resource = new ResourceDictionary
            {
                Source = new Uri(path,UriKind.RelativeOrAbsolute)
            };
            window.Resources.MergedDictionaries.Add(resource);
        }
        public static void ChangePage(Page page)
        {
            var window = GetMainWindow();
            window.framecontent.Content = page;
        }
    }
}
