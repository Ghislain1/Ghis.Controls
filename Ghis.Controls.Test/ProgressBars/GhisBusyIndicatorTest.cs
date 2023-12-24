

namespace Ghis.Controls.Test.ProgressBars
{
    using Ghis.Controls.Test.Shared;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Windows;
    using System.Windows.Media;

    [TestClass]
    public class GhisBusyIndicatorTest
    {
        [WpfUserControlTestMethod, ManualUI]
        public void Show_BusyIndicator_InAction_Test()
        {
            var content = new GhisBusyIndicator();
            content.Height = 400;
            content.Width = 400;
            content.IsIndeterminate = false;
            WpfInteraction.ShowDialog(content);
        }

        [WpfUserControlTestMethod, ManualUI]
        [Description("TODO@GhZe Issue :System.InvalidOperationException: The calling thread must be STA, because many UI components require this. ==> used WpfUserControlTestMethod ")]
        public void DefaultVerticalAlignment_ShouldBeStretch()
        {
            var ghisBusyIndicator = new GhisBusyIndicator();
            // ghisBusyIndicator.ApplyDefaultStyle();

            Assert.AreEqual(VerticalAlignment.Stretch, ghisBusyIndicator.VerticalAlignment);
        }

        [WpfUserControlTestMethod, ManualUI]
        public void HasContent_ShouldBeFalse()
        {
            var ghisBusyIndicator = new GhisBusyIndicator();

            Assert.AreEqual(false, ghisBusyIndicator.HasContent);
        }
    }
}