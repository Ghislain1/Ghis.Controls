// <copyright company="Ghislain One Inc.">
//  Copyright (c) GhislainOne
//  This computer program includes confidential, proprietary
//  information and is a trade secret of GhislainOne. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of Ghis. All Rights Reserved.
// </copyright>

namespace Ghis.Controls.Carousels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;

//[ContentProperty("BBCode")]
public class Carousel : Canvas
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Carousel"/> class.
    /// </summary>
    public Carousel()
    {
        // ensures the implicit BBCodeBlock style is used
        this.DefaultStyleKey = typeof(Carousel);
        this.Background = Brushes.Red;
       // AddHandler(Hyperlink.LoadedEvent, new RoutedEventHandler(OnLoaded));
      //  AddHandler(Hyperlink.RequestNavigateEvent, new RequestNavigateEventHandler(OnRequestNavigate));
    }
}
