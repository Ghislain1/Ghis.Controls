 
using Ghis.Controls.Test.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
 

namespace Ghis.Controls.Test.Charts.Spectrum
{
    [TestClass]
    public class SpectrumAnalyzerTest
    {

        [WpfUserControlTestMethod]
        public void Show_SpectrumAnalyzer_InAction_Test()
        {
            // The following line will not fail unless executed on an STA thread.
            var view = new SpectrumAnalyzerView
            {
                DataContext = new SpectrumAnalyzerViewModel()
            };
            WpfInteraction.ShowDialog(view, titleWindow: "SpectrumAnalyzer in action");

        }
    }
}
