// <copyright company="Ghislain One Inc.">
//  Copyright (c) GhislainOne
//  This computer program includes confidential, proprietary
//  information and is a trade secret of GhislainOne. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of Ghis. All Rights Reserved.
// </copyright>

namespace Ghis.Controls.Test.Magnifier;

using Ghis.Controls.Test.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ghis.Controls.Magnifier;
using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

[TestClass]
public class MagnifierTest
{
    [WpfUserControlTestMethod]
    public void Show_Magnifier_InAction_Test()
    {
        var content = new UserControl();
        var urlString = @"pack://application:,,,/ Ghis.Controls;component/Assets/images/background.love.jpg";   
        var image = new Image() { Source = new BitmapImage(new Uri(urlString, UriKind.Absolute))};
        image.Margin = new System.Windows.Thickness(10);
        content.Background = Brushes.AliceBlue;
        content.Content= image;
        image.SetValue(Magnifier.AddProperty, Magnifier.Default);
        WpfInteraction.ShowDialog(content);
    }
}

