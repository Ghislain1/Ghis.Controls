using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ghis.Windows.Controls.Test.Shared
{
    internal static class WpfInteraction{
        public static void ShowDialog(object contentWindow, int widthWindow=955, int heightWindow=555, string titleWindow = "")
        {
            var ghisApplication = new Application();
            ghisApplication.MainWindow = new Window() { Width=widthWindow, Height=heightWindow, Content=contentWindow, Title= titleWindow, ToolTip=titleWindow, Topmost=true };
            ghisApplication.MainWindow.ShowDialog();

        }
        public static void Show(object contentWindow, int widthWindow = 955, int heightWindow = 555, string titleWindow = "")
        {
            var ghisApplication = new Application();
            ghisApplication.MainWindow = new Window() { Width=widthWindow, Height=heightWindow, Content=contentWindow, Title= titleWindow, ToolTip=titleWindow, Topmost=true };
            ghisApplication.MainWindow.Show();

        }
    }
}
