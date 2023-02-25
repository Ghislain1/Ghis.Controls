// <copyright company="Ghislain One Inc.">
//  Copyright (c) GhislainOne
//  This computer program includes confidential, proprietary
//  information and is a trade secret of GhislainOne. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of Ghis. All Rights Reserved.
// </copyright>

namespace Ghis.Controls.Converters;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

public class EnumComparisonConverter : IValueConverter
{
    public object? Convert(object? value, Type? targetType, object? parameter, CultureInfo culture)
    {
        if ((value is null) || (parameter is null))
        {
            return false;
        }

        var checkValue = value!.ToString();
        var targetValue = parameter!.ToString();
        return checkValue!.Equals(targetValue, StringComparison.InvariantCultureIgnoreCase);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if ((value == null) || (parameter is null))
        {
            return false;
        }

        bool useValue = (bool)value;
        var targetValue = parameter.ToString() ?? string.Empty;
        return useValue ? Enum.Parse(targetType, targetValue) : null;
    }
}