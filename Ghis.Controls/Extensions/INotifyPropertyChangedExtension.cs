// <copyright company="Ghislain One Inc.">
//  Copyright (c) GhislainOne
//  This computer program includes confidential, proprietary
//  information and is a trade secret of GhislainOne. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of Ghis. All Rights Reserved.
// </copyright>

namespace Ghis.Controls.Extensions;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class INotifyPropertyChangedExtension
{
    public static event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;

    public static  void NotifyPropertyChanged(this INotifyPropertyChanged vm,string propertyName)
    {
        if (PropertyChanged  is null)
        {
          return;
        }
        PropertyChanged(vm, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
    }
}
