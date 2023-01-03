using Ghis.Controls.Test.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghis.Controls.Test.ProgressBars
{
    [TestClass]
    public class GhisBusyIndicatorTest
    {
        [WpfUserControlTestMethod]
        public void Show_BusyIndicator_InAction_Test()
        {
            var content = new GhisBusyIndicator() { };
            WpfInteraction.ShowDialog(content); 
        }
    }
}
