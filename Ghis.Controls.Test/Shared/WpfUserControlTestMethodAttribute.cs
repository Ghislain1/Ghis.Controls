namespace Ghis.Controls.Test.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

internal class WpfUserControlTestMethodAttribute : TestMethodAttribute
{
    public override TestResult[] Execute(ITestMethod testMethod)
    {
        if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
        {
            return Invoke(testMethod);
        }

        TestResult[]? result = null;
        var thread = new Thread(() => result = Invoke(testMethod));
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        thread.Join();
        return result;
    }

    private TestResult[] Invoke(ITestMethod testMethod)
    {
        return new[] { testMethod.Invoke(null) };
    }
}