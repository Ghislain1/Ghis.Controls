using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ghis.Windows.Controls.Test.Shared
{
    internal static class DataProvider
    {
        public static void DisplayPropertyInfo(PropertyInfo[] propInfos)
        {
            // Display information for all properties.
            foreach (var propInfo in propInfos)
            {
                bool readable = propInfo.CanRead;
                bool writable = propInfo.CanWrite;

                Console.WriteLine("   Property name: {0}", propInfo.Name);
                Console.WriteLine("   Property type: {0}", propInfo.PropertyType);
                Console.WriteLine("   Read-Write:    {0}", readable & writable);
                if (readable)
                {
                    MethodInfo getAccessor = propInfo.GetMethod!;
                    Console.WriteLine("   Visibility:    {0}", GetVisibility(getAccessor));
                }
                if (writable)
                {
                    MethodInfo setAccessor = propInfo.SetMethod!;
                    Console.WriteLine("   Visibility:    {0}", GetVisibility(setAccessor));
                }
                Console.WriteLine();
            }
        }
        private static string GetVisibility(MethodInfo accessor)
        {
            if (accessor.IsPublic)
                return "Public";
            else if (accessor.IsPrivate)
                return "Private";
            else if (accessor.IsFamily)
                return "Protected";
            else if (accessor.IsAssembly)
                return "Internal/Friend";
            else
                return "Protected Internal/Friend";
        }
        public static PropertyInfo[] GetPublicProperties(Type classType)
        {
            // Type t = typeof(LineChart);
            // Get the public properties.
            PropertyInfo[] propInfos = classType.GetProperties(BindingFlags.Public|BindingFlags.Instance);
            Console.WriteLine("The number of public properties: {0}.\n",
                              propInfos.Length);
            // Display the public properties.
            DisplayPropertyInfo(propInfos);
            return propInfos;
        }
        public static PropertyInfo[] GetNonPublicProperties(Type classType)
        {
            // Get the nonpublic properties.
            PropertyInfo[] propInfos1 = classType.GetProperties(BindingFlags.NonPublic|BindingFlags.Instance);
            Console.WriteLine("The number of non-public properties: {0}.\n", propInfos1.Length);
            // Display all the nonpublic properties.
            DisplayPropertyInfo(propInfos1);
            return propInfos1;
        }

        public static (double []XValues, double []YValues) GetSinWave(int numberOfPoints=8000)
        {

            double[] y = new double[numberOfPoints];
            double[] x = new double[numberOfPoints];
            double amplitude = 0.25 * short.MaxValue;
            double frequency = 1000;
            for (int k = 0; k< y.Length; k++)
            {
                x[k]=(2 * Math.PI * k * frequency);
                y[k] = amplitude * Math.Sin(x[k]) / numberOfPoints;
                 
            }
            return (x, y);

        }
    }
}
