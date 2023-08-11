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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;

public class AdornerContainer : Adorner
{
    private UIElement _child;
    public AdornerContainer(UIElement adornedElement) : base(adornedElement)
    {
    }
    public UIElement Child
    {
        get => _child;
        set
        {
            if (value == null)
            {
                RemoveVisualChild(_child);
                _child = value;
                return;
            }
            AddVisualChild(value);
            _child = value;
        }
    }
    protected override int VisualChildrenCount
    {
        get
        {
            return _child != null ? 1 : 0;
        }
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        _child?.Arrange(new Rect(finalSize));
        return finalSize;
    }

    protected override Visual GetVisualChild(int index)
    {
        if (index == 0 && _child != null) return _child;
        return base.GetVisualChild(index);
    }
}