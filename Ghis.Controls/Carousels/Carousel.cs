// <copyright company="Ghislain One Inc.">
//  Copyright (c) GhislainOne
//  This computer program includes confidential, proprietary
//  information and is a trade secret of GhislainOne. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of Ghis. All Rights Reserved.
// </copyright>

namespace Ghis.Controls.Carousels;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Threading;

//[ContentProperty("BBCode")]
public class Carousel : Canvas
{
    /*
     * Use   to host the carousel items.
     */
    private Canvas canvas;
    private DateTime previousTime;
    private DispatcherTimer timer = new DispatcherTimer();
    private double rotationToGo = 0;
    private double currentRotation = 0;
    private const double constMinimumFade = 0;
    private const double constMaximumFade = 1;
    private const double constMinimumScale = 0;
    private const double constMaximumScale = 1;
    private const double constMinimumLookdownOffset = -100;
    private const double constMaximumLookdownOffset = 100;
    private const double constMinimumRotationSpeed = 1;
    private const double constMaximumRotationSpeed = 1000;

    // [Bindable(true)] TODO@Ghis  Why?
    // [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]  TODO@Ghis  Why?
    public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(Carousel), new FrameworkPropertyMetadata((IEnumerable)null, new PropertyChangedCallback(OnItemsSourceChanged)));
    public static readonly DependencyProperty CarouselItemTemplateProperty = DependencyProperty.Register(nameof(CarouselItemTemplate), typeof(ControlTemplate), typeof(Carousel), new FrameworkPropertyMetadata(null, new PropertyChangedCallback((d, e) => ((Carousel)d).OnCarouselItemTemplateChanged(e))));
    public static readonly DependencyProperty FadeProperty = DependencyProperty.Register("Fade", typeof(double), typeof(Carousel), new FrameworkPropertyMetadata(0.5, new PropertyChangedCallback((d, e) => ((Carousel)d).OnFadeChanged(e))));
    public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(Carousel), new FrameworkPropertyMetadata((FrameworkElement)null, new PropertyChangedCallback((d, e) => ((Carousel)d).OnSelectedItemChanged(e))));
    public static readonly DependencyProperty ScaleProperty = DependencyProperty.Register("ScaleProperty", typeof(double), typeof(Carousel), new FrameworkPropertyMetadata(0.5, new PropertyChangedCallback((d, e) => ((Carousel)d).OnScaleChanged(e))));
    public static readonly DependencyProperty TiltInDegreesProperty = DependencyProperty.Register("TiltInDegrees", typeof(double), typeof(Carousel), new FrameworkPropertyMetadata(0.0, new PropertyChangedCallback((d, e) => ((Carousel)d).OnTiltInDegreesChanged(e))));
    public static readonly DependencyProperty RotationSpeedProperty = DependencyProperty.Register("RotationSpeed", typeof(double), typeof(Carousel), new FrameworkPropertyMetadata(constMaximumRotationSpeed, new PropertyChangedCallback((d, e) => ((Carousel)d).OnRotationSpeedChanged(e))));
    public static readonly DependencyProperty AutoSizeToParentProperty = DependencyProperty.Register("AutoSizeToParent", typeof(bool), typeof(Carousel), new FrameworkPropertyMetadata(true, new PropertyChangedCallback((d, e) => ((Carousel)d).OnAutoSizeToParentChanged(e))));
    public static readonly DependencyProperty VerticalOrientationProperty = DependencyProperty.Register("VerticalOrientationProperty", typeof(bool), typeof(Carousel), new FrameworkPropertyMetadata(false, new PropertyChangedCallback((d, e) => ((Carousel)d).OnVerticalOrientationChanged(e))));

    public delegate void SelectionChangedEventHandler(FrameworkElement selectedElement);
    public event SelectionChangedEventHandler SelectionChanged;
    public bool AutoSizeToParent
    {
        get
        {
            return (bool)GetValue(AutoSizeToParentProperty);
        }
        set
        {
            SetValue(AutoSizeToParentProperty, value);
        }
    }
    public double RotationSpeed
    {
        get => (double)GetValue(RotationSpeedProperty);
        set => SetValue(RotationSpeedProperty, Math.Min(Math.Max(value, constMinimumRotationSpeed), constMaximumRotationSpeed));
    }
    public bool VerticalOrientation
    {
        get => (bool)GetValue(VerticalOrientationProperty);
        set => SetValue(VerticalOrientationProperty, value);
    }
    public double Scale
    {
        get => (double)GetValue(ScaleProperty);
        set => SetValue(ScaleProperty, Math.Min(Math.Max(value, constMinimumScale), constMaximumScale));
    }

    public double Fade
    {
        get => (double)GetValue(FadeProperty);
        set => SetValue(FadeProperty, Math.Min(Math.Max(value, constMinimumFade), constMaximumFade));
    }

    public ControlTemplate CarouselItemTemplate
    {
        get => (ControlTemplate)GetValue(CarouselItemTemplateProperty);
        set => SetValue(CarouselItemTemplateProperty, value);
    }
    public double TiltInDegrees
    {
        get
        {
            return (double)GetValue(TiltInDegreesProperty);
        }
        set
        {
            SetValue(TiltInDegreesProperty, Math.Min(Math.Max(value, constMinimumLookdownOffset), constMaximumLookdownOffset));
        }
    }
    public IEnumerable ItemsSource
    {
        get => (IEnumerable)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Carousel"/> class.
    /// </summary>
    public Carousel()
    {
        // ensures the implicit BBCodeBlock style is used
        this.DefaultStyleKey = typeof(Carousel);
        this.Background = Brushes.Transparent;
        this.LayoutUpdated += OnLayoutUpdated;
        this.timer.Tick += this.TimerTick;
        this.timer.Interval = TimeSpan.FromMilliseconds(10);
        this.canvas = new Canvas();
        this.canvas.HorizontalAlignment = HorizontalAlignment.Stretch;
        this.canvas.VerticalAlignment = VerticalAlignment.Stretch;

        Children.Add(this.canvas);

        // AddHandler(Hyperlink.LoadedEvent, new RoutedEventHandler(OnLoaded));
        //  AddHandler(Hyperlink.RequestNavigateEvent, new RequestNavigateEventHandler(OnRequestNavigate));
    }
    ~Carousel()
    {
        this.timer.Tick -= this.TimerTick;
    }
    public object SelectedItem
    {
        get
        {
            return GetValue(SelectedItemProperty);
        }
        set
        {
            if (value != SelectedItem)
            {
                SetValue(SelectedItemProperty, value);
            }
        }
    }
    protected virtual void OnTiltInDegreesChanged(DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue != null)
        {
            TiltInDegrees = (double)e.NewValue;
        }
    }
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
    }
    protected virtual void OnAutoSizeToParentChanged(DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue != null)
        {
            AutoSizeToParent = (bool)e.NewValue;
        }
    }
    protected virtual void OnRotationSpeedChanged(DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue != null)
        {
            RotationSpeed = (double)e.NewValue;
        }
    }
    protected virtual void OnSelectedItemChanged(DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue != null)
        {
            for (int index = 0; index < this.canvas.Children.Count; index++)
            {
                FrameworkElement element = GetChild(index);
                if (element.DataContext == e.NewValue)
                {
                    this.SelectElement(element);
                    return;
                }
            }
        }
    }
    public bool ShowRotation { get; set; }
    private void SelectElement(FrameworkElement element)
    {
        if (element != null)
        {
            this.previousTime = DateTime.Now;
            RotateToElement(element);
            SelectedItem = element.DataContext;
            if (SelectionChanged != null)
            {
                SelectionChanged(element);
            }
        }
    }
    protected virtual void OnCarouselItemTemplateChanged(DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue != null)
        {
            CarouselItemTemplate = (ControlTemplate)e.NewValue;
        }
    }
    private double GetDegreesNeededToPlaceElementInFront(int targetIndex)
    {
        double rawDegrees = this.currentRotation - 180.0 + (360.0 * (double)targetIndex) / (double)this.canvas.Children.Count;

        if (rawDegrees > 180.0)
        {
            return -(360.0 - rawDegrees);
        }

        return rawDegrees;
    }
    protected virtual void OnScaleChanged(DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue != null)
        {
            Scale = (double)e.NewValue;
        }
    }
    private void RotateToElement(FrameworkElement element)
    {
        SelectedItem = element.DataContext;
        int targetIndex = this.canvas.Children.IndexOf(element);

        double degreesToRotate = GetDegreesNeededToPlaceElementInFront(targetIndex);

        if (!ShowRotation)
        {
            this.currentRotation = ClampDegrees(this.currentRotation - degreesToRotate);
            SetElementPositions();
        }
        else
        {
            StartRotation(degreesToRotate);
        }
    }
    private void PrepareItemsSource(IEnumerable itemsSource)
    {
        this.canvas.Children.Clear();

        foreach (var item in itemsSource)
        {
            var itemControl = new Control();
            itemControl.Template = this.CarouselItemTemplate;

            itemControl.DataContext = item;
            this.canvas.Children.Add(itemControl);
        }

        AddMouseLeftButtonDownHandlers();
        bool showRotation = ShowRotation;
        ShowRotation = false;
        this.ResetLayout();
        ShowRotation = showRotation;
    }
    private void ResetLayout()
    {
        this.previousTime = DateTime.Now;

        if (SelectedItem == null)
        {
            SelectElement(GetChild(0));
        }

        SetElementPositions();
    }
    private void CarouselControl_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        PrepareItemsSource(ItemsSource);
    }
    private FrameworkElement GetChild(int index)
    {
        if ((this.canvas.Children.Count == 0) || (index >= this.canvas.Children.Count))
        {
            return null;
        }

        FrameworkElement element = this.canvas.Children[index] as FrameworkElement;

        if (element == null)
        {
            throw new NotSupportedException("Carousel only supports children that are Framework elements");
        }

        return element;
    }
    private double ClampDegrees(double rawDegrees)
    {
        if (rawDegrees > 360.0)
        {
            return rawDegrees - 360.0;
        }

        if (rawDegrees < 0.0)
        {
            return rawDegrees + 360.0;
        }

        return rawDegrees;
    }
    private double DegreesToRadians(double degrees)
    {
        return degrees * Math.PI / 180.0;
    }
    private double RadiansToDegrees(double radians)
    {
        return (360.0 * radians) / (Math.PI + Math.PI);
    }
    private double GetCoefficient(double degrees)
    {
        return (1.0 - Math.Cos(DegreesToRadians(degrees))) / 2.0;
    }
    private void SetOpacity(FrameworkElement element, double degrees)
    {
        element.Opacity = (1.0 - Fade) + Fade * GetCoefficient(degrees);
    }
    private double GetScaledSize(double degrees)
    {
        return (1.0 - Scale) + Scale * GetCoefficient(degrees);
    }
    private int GetZValue(double degrees)
    {
        return (int)(360 * GetCoefficient(degrees));
    }
    private void SetElementPositions()
    {
        if (this.canvas.Children.Count <= 0)
        {
            return;
        }

        FrameworkElement element = this.GetChild(0);

        double elementHalfWidth = element.ActualWidth / 2.0;
        double elementHalfHeight = element.ActualHeight / 2.0;
        double canvasHalfWidth = VerticalOrientation ? 0 : ActualWidth / 2.0 - elementHalfWidth;
        double canvasHalfHeight = VerticalOrientation ? canvasHalfHeight = ActualHeight / 2.0 - elementHalfHeight : 0;

        for (int index = 0; index < this.canvas.Children.Count; index++)
        {
            double degrees = (360.0 * (double)index) / (double)this.canvas.Children.Count + this.currentRotation;
            double cosineAngle = Math.Cos(DegreesToRadians(degrees));
            double sineAngle = Math.Sin(DegreesToRadians(degrees));

            element = GetChild(index);

            double x = -canvasHalfWidth * sineAngle - (double.IsNaN(canvasHalfHeight) ? 0.0 : canvasHalfHeight / 100.0) * cosineAngle * this.TiltInDegrees;
            Canvas.SetLeft(element, x + ActualWidth / 2.0 - elementHalfWidth);

            double y = canvasHalfHeight * sineAngle - (double.IsNaN(canvasHalfWidth) ? 0.0 : canvasHalfWidth / 100.0) * cosineAngle * this.TiltInDegrees;
            Canvas.SetTop(element, y + ActualHeight / 2.0 - elementHalfHeight);

            ScaleTransform scale = element.RenderTransform as ScaleTransform;
            if (scale == null)
            {
                scale = new ScaleTransform();
                element.RenderTransform = scale;
            }

            scale.CenterX = elementHalfWidth;
            scale.CenterY = elementHalfHeight;
            double scaledSize = GetScaledSize(degrees);
            scale.ScaleX = scale.ScaleY = scaledSize * scaledSize;
            Canvas.SetZIndex(element, GetZValue(degrees));

            SetOpacity(element, degrees);
        }
    }
    private void OnLayoutUpdated(object? sender, EventArgs e)
    {
        this.Background = Brushes.Beige;
        this.SetElementPositions();
    }
    private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((Carousel)d).OnItemsSourceChanged(e);
    }
    protected virtual void OnItemsSourceChanged(DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue != null)
        {
            PrepareItemsSource(e.NewValue as IEnumerable);

            if (ItemsSource is System.Collections.Specialized.INotifyCollectionChanged)
            {
                (ItemsSource as System.Collections.Specialized.INotifyCollectionChanged).CollectionChanged += CarouselControl_CollectionChanged;
            }
        }
    }
    protected virtual void OnFadeChanged(DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue != null)
        {
            Fade = (double)e.NewValue;
        }
    }
    private void AddMouseLeftButtonDownHandlers()
    {
        foreach (FrameworkElement element in this.canvas.Children)
        {
            element.MouseLeftButtonDown += element_MouseLeftButtonDown;
            element.Unloaded += delegate { MouseLeftButtonDown -= element_MouseLeftButtonDown; };
            element.Cursor = Cursors.Hand;
        }

        MouseWheel += CarouselControl_MouseWheel;
    }
    private void element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        RotateToElement(sender as FrameworkElement);
    }
    private void CarouselControl_MouseWheel(object sender, MouseWheelEventArgs e)
    {
        if (e.LeftButton != MouseButtonState.Pressed)
        {
            return;
        }

        this.StartRotation(e.Delta / 2);
    }
    private void StartRotation(double numberOfDegrees)
    {
        this.rotationToGo = numberOfDegrees;
        this.previousTime = DateTime.Now;
        if (!this.timer.IsEnabled)
        {
            this.timer.Start();
        }
    }
    private void TimerTick(object? sender, EventArgs e)
    {
        DateTime timeNow = DateTime.Now;
        double rotationAmount = (timeNow - this.previousTime).TotalSeconds * RotationSpeed;
        this.previousTime = timeNow;

        if (Math.Abs(this.rotationToGo) < rotationAmount)
        {
            rotationAmount = Math.Abs(this.rotationToGo);
            this.timer.Stop();
        }

        if (this.rotationToGo < 0.0)
        {
            rotationAmount = -rotationAmount;
        }

        this.rotationToGo -= rotationAmount;
        this.currentRotation = ClampDegrees(this.currentRotation - rotationAmount);

        SetElementPositions();
    }
    protected virtual void OnVerticalOrientationChanged(DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue != null)
        {
            VerticalOrientation = (bool)e.NewValue;
            ResetLayout();
        }
    }
}