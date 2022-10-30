using Ghis.Windows.Controls.Test.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Ghis.Windows.Controls.Test.Charts
{
    [TestClass]
    public  class LineChartTest
    {
       // TODO:
       // 1. Write test in output console for tests
       // use edit config

        [WpfUserControlTestMethod]
        public void Show_LineChart_InAction_Test()
        {
            // The following line will not fail unless executed on an STA thread.
            var content = new LineChartView();
            content.DataContext = new LineChartViewModel();
            WpfInteraction.ShowDialog(content, titleWindow: "Line Chart in action") ;
         
        }


    }
}
