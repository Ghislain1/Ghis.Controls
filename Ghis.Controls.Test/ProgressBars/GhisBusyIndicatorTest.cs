using Ghis.Controls.Test.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
 
namespace Ghis.Controls.Test.ProgressBars
{
    [TestClass]
    public class GhisBusyIndicatorTest
    {
        [WpfUserControlTestMethod]
        public void Show_BusyIndicator_InAction_Test()
        {
            var content = new GhisBusyIndicator() ;
            content.IsBusy = true;
            WpfInteraction.ShowDialog(content); 
        }
    }
}
