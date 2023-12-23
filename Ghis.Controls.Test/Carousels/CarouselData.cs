﻿// <copyright company="Ghislain One Inc.">
//  Copyright (c) GhislainOne
//  This computer program includes confidential, proprietary
//  information and is a trade secret of GhislainOne. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of Ghis. All Rights Reserved.
// </copyright>

namespace Ghis.Controls.Test.Carousels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

public class CarouselData
{
    public string? Name { get; set; }
    public string? ShortName { get; set; }
    public string? ImageSource { get; set; }
    public string? Text { get; set; }   
    public BitmapImage? BitmapImage  => new BitmapImage(new Uri(this.ImageSource??throw new ArgumentNullException(nameof(this.ImageSource)), UriKind.Relative));
}
