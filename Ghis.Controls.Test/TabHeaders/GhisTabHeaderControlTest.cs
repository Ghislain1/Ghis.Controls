// <copyright company="Ghislain One Inc.">
//  Copyright (c) GhislainOne
//  This computer program includes confidential, proprietary
//  information and is a trade secret of GhislainOne. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of Ghis. All Rights Reserved.
// </copyright>

namespace Ghis.Controls.Test.TabHeaders;

using Ghis.Controls.TabHeaders;
using Ghis.Controls.Test.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

[TestClass]
public class GhisTabHeaderControlTest
{
    [WpfUserControlTestMethod]
    public void Show_GhisTabHeaderControl_InAction_Test()
    {
        var content = this.CreateControl();
        content.Height = 400;
        //content.Width = 400;
        content.IsActive = true;
        //  Enumerable.Range(1,150).Select(item => content.Items.Add( new TabHeaderItem() { Label = $"Nr item {item}" , ID=item  })).ToArray();
        content.Items.Add(new TabHeaderItem() { ID = 0, Label = "Short item" });
        content.Items.Add(new TabHeaderItem() { ID = 1, Label = "A longer item" });
        content.Items.Add(new TabHeaderItem() { ID = 2, Label = "A quite long item" });
        content.Items.Add(new TabHeaderItem() { ID = 3, Label = "A really quite long item" });
        content.SelectedTabBackground = Brushes.AliceBlue;

        WpfInteraction.ShowDialog(content);
    }
    private GhisTabHeaderControl CreateControl()
    {
        var item = new GhisTabHeaderControl();
        item.SelectedTabForeground = System.Windows.Media.Brushes.Black;
        item.SelectedTabBackground = System.Windows.Media.Brushes.AliceBlue;
        item.UnselectedTabForeground = System.Windows.Media.Brushes.White;
        item.UnselectedTabBackground = System.Windows.Media.Brushes.CornflowerBlue;
        //var rd = (ResourceDictionary)Application.LoadComponent(new Uri("/Ghis.Control;component/Themes/Generic.xaml", UriKind.Relative));
        //item.Resources = rd;

        return item;
    }

    public class TabHeaderItem
    {
        public string Label { get; set; }
        public int ID { get; set; }

        public string HeaderText
        {
            get
            {
                return Label + " : " + ID;
            }
        }
    }
}