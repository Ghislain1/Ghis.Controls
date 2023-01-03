 
using System.Windows;

namespace Ghis.Controls.Test.Shared
{
    internal static class WpfInteraction{
        public static void ShowDialog(object contentWindow, int widthWindow=955, int heightWindow=555, string titleWindow = "")
        {
            var ghisApplication = new Application();
            //pack://application:,,,/MyLib;component/SettingsPage.xaml           
            var allResources = new ResourceDictionary() { Source = new Uri(@"Ghis.Controls;component\Themes\Generic.xaml", UriKind.Relative) };
            ghisApplication.Resources.MergedDictionaries.Add(allResources);
            ghisApplication.MainWindow = new Window() { Width=widthWindow, Height=heightWindow, Content=contentWindow, Title= titleWindow, ToolTip=titleWindow, Topmost=false };
            ghisApplication.MainWindow.ShowDialog();

        }
        public static void Show(object contentWindow, int widthWindow = 955, int heightWindow = 555, string titleWindow = "")
        {
            var ghisApplication = new Application();
            ghisApplication.MainWindow = new Window() { Width=widthWindow, Height=heightWindow, Content=contentWindow, Title= titleWindow, ToolTip=titleWindow, Topmost=false };
            ghisApplication.MainWindow.Show();

        }
    }
}
