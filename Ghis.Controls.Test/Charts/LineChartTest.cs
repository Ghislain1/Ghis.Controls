namespace Ghis.Controls.Test.Charts;

using Ghis.Controls.Charts;
using Ghis.Controls.Test.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Windows.Controls;

[TestClass]
public class LineChartTest
{
    // TODO:
    // 1. Write test in output console for tests
    // use edit config

    [WpfUserControlTestMethod, ManualUI]
    public void Show_LineChart_InAction_Test()
    {
        // The following line will not fail unless executed on an STA thread.
        var content = new LineChartView();
        content.DataContext = new LineChartViewModel();
        WpfInteraction.ShowDialog(content, titleWindow: "Line Chart in action");

    }
    [WpfUserControlTestMethod, ManualUI]
    public void TestLine_Init_Property_True()
    {

        // In General is Dat for Fluentassertions
        var lineChart = new LineChart();

        //Assert
        lineChart.ValueAxisItemTemplate.Should().NotBeNull();
    }


}