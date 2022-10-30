using Ghis.Windows.Controls.Charts;
using Ghis.Windows.Controls.Test.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ghis.Windows.Controls.Test.Charts
{
    internal class LineChartViewModel
    {
        private ObservableCollection<object> historyCollection;
        public ObservableCollection<object> HistoryCollection => this.historyCollection??=new ObservableCollection<object>();
        public ObservableCollection<PropertyInfo> PropertyInfoCollection { get; private set; }
        public string Title => "Line Chart :D";

        public LineChartViewModel() => this.Load();

        private async void Load()
        {
            await Task.Run(() =>
            {
                var propInfos=DataProvider.GetPublicProperties(typeof(LineChart));
                var propInfos1 = DataProvider.GetNonPublicProperties(typeof(LineChart));
                this.PropertyInfoCollection=  new ObservableCollection<PropertyInfo>( propInfos.Concat(propInfos1));
            });

            for (int i = 0; i < 10; i++)
            {
                this.HistoryCollection.Add(new LineChartModel() { ValuePathData = i });

            }
        }

     
    }
}
