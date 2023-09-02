```
_______________
|
|
|
|       ____________
|                   |
|                   |
|                   |
|___________________|


```

# Ghis.Controls
A Container of  some pretty and commonly used WPF controls 

# How to use it
* Add Add the Ghis.Windows.Controls NuGet package 
* Setup xmlns:ghis="clr-namespace:Ghis.Windows.Controls;assembly=Ghis.Windows.Controls" in your desired xaml file
* Use any controls e.g. 
``` xaml
 <Grid>
        <ghis:GhisBusyIndicator IsBusy="True" />
 </Grid>
```
# How to create any own Control
- Add suitable folder under Ghis.Control cproj
- Add Control(to implement your control) class with suitable name in previous folder .i.e Carousel
       -  Extended the class with WPF control for i.e. Canvas
       -  Define some DependencyProperties 
       -       
- Add Resource file(to define style of your control) same as control i.e Carousel.xaml
- Add  previous file in Generic.xaml (Themes) to explose it out!