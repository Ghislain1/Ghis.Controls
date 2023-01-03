using Ghis.Controls.Charts;
using Ghis.Controls.Test.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Ghis.Controls.Test.Charts
{
    internal class LineChartViewModel : BindableBase
    {
        private ObservableCollection<object>? historyCollection;
        public ObservableCollection<object> HistoryCollection => this.historyCollection??=new ObservableCollection<object>();
        public ObservableCollection<PropertyInfo>? PropertyInfoCollection { get; private set; }
        private string title;
        private string labelAxisTitle;
        private bool showLabelAxisTicks;
        private static object _lock = new object();

        public bool ShowLabelAxisTicks
        {
            get => this.showLabelAxisTicks;
            set => this.SetProperty(ref this.showLabelAxisTicks, value);
        }
        public string LabelAxisTitle
        {
            get => this.labelAxisTitle;
            set => this.SetProperty(ref this.labelAxisTitle, value);
        }
        

        public string Title
        {
            get => this.title;
            set => this.SetProperty(ref this.title, value);
        }
        public LineChartViewModel()
        {
            BindingOperations.EnableCollectionSynchronization(this.HistoryCollection, _lock);
         //  this.Load();
           SimulateTitle();
        }
        private async void SimulateTitle()
        {
            int count = 0;      
            while (true)
            {
                await Task.Delay(3000);
                this.Title = $"Line Chart ({count}) ";
                this.LabelAxisTitle =this.Title;
                count++;
                this.ShowLabelAxisTicks=!this.ShowLabelAxisTicks;
                this.HistoryCollection.Clear();
                for (int i = 0; i < 10; i++)
                {
                   this.HistoryCollection.Add(new LineChartModel() { YValue = i*2, XValue=i });

                }
                if (count%7==0)
                {
                    this.HistoryCollection.Clear();
                    await this.Load();
                }
            }
           
         }
        private async Task Load()
        {
            await Task.Run(() =>
            {
                var propInfos = DataProvider.GetPublicProperties(typeof(LineChart));
                var propInfos1 = DataProvider.GetNonPublicProperties(typeof(LineChart));
                this.PropertyInfoCollection=  new ObservableCollection<PropertyInfo>(propInfos.Concat(propInfos1));
            });
            var sins = DataProvider.GetSinWave(10);
            for (int i = 0; i < sins.XValues.Length; i++)
            {
                this.HistoryCollection.Add(new LineChartModel() 
                { 
                    YValue = sins.YValues[i], 
                    XValue=(short)sins.XValues[i] 
                });

            }
        }


    }
}
