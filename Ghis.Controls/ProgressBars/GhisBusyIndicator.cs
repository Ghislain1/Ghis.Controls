

namespace Ghis.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
/// <summary> Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
///
/// Step 1a) Using this custom control in a XAML file that exists in the current project. Add
/// this XmlNamespace attribute to the root element of the markup file where it is to be used:
///
/// xmlns:MyNamespace="clr-namespace:Ghis.Controls"
///
///
/// Step 1b) Using this custom control in a XAML file that exists in a different project. Add
/// this XmlNamespace attribute to the root element of the markup file where it is to be used:
///
/// xmlns:MyNamespace="clr-namespace:Ghis.Controls;assembly=Ghis.Controls"
///
/// You will also need to add a project reference from the project where the XAML file lives to
/// this project and Rebuild to avoid compilation errors:
///
/// Right click on the target project in the Solution Explorer and "Add
/// Reference"->"Projects"->[Select this project]
///
///
/// Step 2) Go ahead and use your control in the XAML file.
///
/// <MyNamespace:CustomControl1/>
///
///
///
/// Represents a control that indicates that an operation is ongoing. </summary>
    [TemplateVisualState(GroupName = GroupActiveStates, Name = StateInactive)]
    [TemplateVisualState(GroupName = GroupActiveStates, Name = StateActive)]
    public class GhisBusyIndicator : ContentControl
    {
        /// <summary> Identifies the ProgressBarStyle property. </summary
        public static readonly DependencyProperty BusyContentProperty = DependencyProperty.Register("BusyContent", typeof(object), typeof(GhisBusyIndicator), new PropertyMetadata("BusyIndicatorLoading"));

        /// <summary> Identifies the ProgressBarStyle property. </summary
        public static readonly DependencyProperty BusyContentTemplateProperty = DependencyProperty.Register("BusyContentTemplate", typeof(DataTemplate), typeof(GhisBusyIndicator), new PropertyMetadata(null));

        /// <summary> Identifies the ProgressBarStyle property. </summary
        public static readonly DependencyProperty DisplayAfterProperty = DependencyProperty.Register("DisplayAfter", typeof(TimeSpan), typeof(GhisBusyIndicator), new PropertyMetadata(TimeSpan.FromSeconds(0.1)));

        /// <summary> Identifies the ProgressBarStyle property. </summary
        public static readonly DependencyProperty IsBusyIndicationVisibleProperty;

        /// <summary> Identifies the ProgressBarStyle property. </summary
        public static readonly DependencyProperty IsBusyProperty = DependencyProperty.Register("IsBusy", typeof(bool), typeof(GhisBusyIndicator), new PropertyMetadata(false, new PropertyChangedCallback(GhisBusyIndicator.OnIsBusyChanged)));

        /// <summary> Identifies the ProgressBarStyle property. </summary
        public static readonly DependencyProperty IsIndeterminateProperty = DependencyProperty.Register(nameof(IsIndeterminate), typeof(bool), typeof(GhisBusyIndicator), new PropertyMetadata(true));

        /// <summary> Identifies the ProgressBarStyle property. </summary// Token: 0x04000093 RID: 147
        public static readonly DependencyProperty OverlayStyleProperty = DependencyProperty.Register("OverlayStyle", typeof(Style), typeof(GhisBusyIndicator), new PropertyMetadata(new PropertyChangedCallback(GhisBusyIndicator.PatchInlineStyle)));

        /// <summary> Identifies the ProgressBarStyle property. </summary
        public static readonly DependencyProperty ProgressBarStyleProperty = DependencyProperty.Register("ProgressBarStyle", typeof(Style), typeof(GhisBusyIndicator), new PropertyMetadata(new PropertyChangedCallback(GhisBusyIndicator.PatchInlineStyle)));

        /// <summary> Identifies the ProgressValue property.
        ///
        /// </summary
        public static readonly DependencyProperty ProgressValueProperty = DependencyProperty.Register("ProgressValue", typeof(double), typeof(GhisBusyIndicator), new PropertyMetadata(0.0, new PropertyChangedCallback(GhisBusyIndicator.OnProgressValuePropertyChanged)));

        private const string GroupActiveStates = "ActiveStates";
        private const string StateActive = "Active";
        private const string StateInactive = "Inactive";

        static GhisBusyIndicator()
        {
            //TODO@Ghis == why? ovverrideMetadata hier?
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GhisBusyIndicator), new FrameworkPropertyMetadata(typeof(GhisBusyIndicator)));
        }

        /// <summary>
        /// Gets or sets the busy value.
        /// </summary>
        public bool IsBusy
        {
            get => (bool)GetValue(IsBusyProperty); 
            set =>  SetValue(IsBusyProperty, value);  
        }

        public bool IsIndeterminate
        {
            get => (bool)GetValue(IsIndeterminateProperty);
            set => SetValue(IsIndeterminateProperty, value);
        }

        

        /// <summary>
        /// Gets or sets the progress value.
        /// </summary>
        public double ProgressValue
        {
            get => (double)GetValue(ProgressValueProperty); 
            set =>  SetValue(ProgressValueProperty, value); 
        }

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal
        /// processes call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            SetCurrentState(false);
        }

        private static void OnIsBusyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((GhisBusyIndicator)d).SetCurrentState(true);
        }

        private static void OnProgressValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // TODO: Check Mui  how he does
        }

        private static void PatchInlineStyle(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // TODO: Check Mui  how he does
        }

        private void SetCurrentState(bool animate)
        {
            var state = !IsBusy ? StateActive : StateInactive;

            VisualStateManager.GoToState(this, state, animate);
        }
    }
