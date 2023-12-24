// <copyright company="Ghislain One Inc.">
//  Copyright (c) GhislainOne
//  This computer program includes confidential, proprietary
//  information and is a trade secret of GhislainOne. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of Ghis. All Rights Reserved.
// </copyright>

namespace Ghis.Controls.Test.Carousels;

using Ghis.Controls.Carousels;
using Ghis.Controls.Test.Charts;
using Ghis.Controls.Test.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

[TestClass]
public class CarouselTest
{
    [WpfUserControlTestMethod, ManualUI]
    public void Carousel_InAction() => WpfInteraction.ShowDialog(new CarouselView() { DataContext = new CarouselViewModel() }, titleWindow: $"{nameof(Carousel)} in Action");

}