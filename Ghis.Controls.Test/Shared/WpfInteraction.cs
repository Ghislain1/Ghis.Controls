namespace Ghis.Controls.Test.Shared
{

    using System.Windows;

    internal static class WpfInteraction
    {
        public static void ShowDialog(object contentWindow, int widthWindow = 955, int heightWindow = 555, string titleWindow = "")
        {
            Application ghisApplication;
            if (Application.Current is not null)
            {
                ghisApplication = (Application)Application.Current;
            }
            else
            {
                ghisApplication = new Application();
                var allResources = new ResourceDictionary() { Source = new Uri(@"Ghis.Controls;component\Themes\Generic.xaml", UriKind.Relative) };
                ghisApplication.Resources.MergedDictionaries.Add(allResources);
            }

            ghisApplication.MainWindow = new Window() { Width = widthWindow, Height = heightWindow, Content = contentWindow, Title = titleWindow, ToolTip = titleWindow, Topmost = false };
            ghisApplication.MainWindow.ShowDialog();




        }
        public static void Show(object contentWindow, int widthWindow = 955, int heightWindow = 555, string titleWindow = "")
        {
            var ghisApplication = new Application();
            ghisApplication.MainWindow = new Window() { Width = widthWindow, Height = heightWindow, Content = contentWindow, Title = titleWindow, ToolTip = titleWindow, Topmost = false };
            ghisApplication.MainWindow.Show();

        }
    }
}