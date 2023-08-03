using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.Managers
{
    public static class MyThemeManager
    {
        public static void SetLightTheme()
        {
            ResourceManager.DeleteResource(@"Styles/DarkStyles.xaml");
            ResourceManager.AddResource(@"Styles/LightStyles.xaml");
        }
        public static void SetDarkTheme()
        {
            ResourceManager.DeleteResource(@"Styles/LightStyles.xaml");
            ResourceManager.AddResource(@"Styles/DarkStyles.xaml");
        }
    }
}
