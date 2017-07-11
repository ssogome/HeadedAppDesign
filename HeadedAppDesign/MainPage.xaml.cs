using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HeadedAppDesign
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Style coloredButtonStyle = new Style(typeof(Button));
        private const string pointerOverVisualStateName = "PointerOver";
        private const string normalVisualStateName = "Normal";

        public MainPage()
        {
            this.InitializeComponent();

            SetStylePropertySetters();

            GoToStateButton.Style = coloredButtonStyle;
        }

        private void SetStylePropertySetters()
        {
            coloredButtonStyle.Setters.Add(new Setter(BorderThicknessProperty, 0.5));
            coloredButtonStyle.Setters.Add(new Setter(BorderBrushProperty, Colors.Black));
            coloredButtonStyle.Setters.Add(new Setter(FontSizeProperty, 20));
            coloredButtonStyle.Setters.Add(new Setter(ForegroundProperty, Colors.White));
            coloredButtonStyle.Setters.Add(new Setter(MarginProperty, new Thickness(10, 10, 0, 0)));
            coloredButtonStyle.Setters.Add(new Setter(BackgroundProperty, GenerateGradient()));
        }
        private LinearGradientBrush GenerateGradient()
        {
            var gradientStopCollection = new GradientStopCollection();

            gradientStopCollection.Add(new GradientStop()
            {
                Color = Colors.Yellow,
                Offset = 0
            });

            gradientStopCollection.Add(new GradientStop()
            {
                Color = Colors.Orange,
                Offset = 0.5
            });

            gradientStopCollection.Add(new GradientStop()
            {
                Color = Colors.Red,
                Offset = 1.0
            });

            return new LinearGradientBrush(gradientStopCollection, 0.0);
        }

        private void GoToStateButton_Click(object sender, RoutedEventArgs e)
        {
            SwapButtonVisualState(IoTButton);
            SwapButtonVisualState(Windows10IoTCoreButton);
        }

        private void SwapButtonVisualState(Button button)
        {
            string newVisualState = pointerOverVisualStateName;
            if(button.Tag != null)
            {
                if (button.Tag.ToString().Contains(pointerOverVisualStateName))
                {
                    newVisualState = normalVisualStateName;
                }
                else
                {
                    newVisualState = pointerOverVisualStateName;
                }
            }

            VisualStateManager.GoToState(button, newVisualState, false);

            button.Tag = newVisualState;
        }

        private void Windows10IoTCoreButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private Style GetStyleFromResourceDictionary(ResourceDictionary resourceDictionary, string styleKey)
        {
            Style style = null;

             if(resourceDictionary != null && !string.IsNullOrWhiteSpace(styleKey))
            {
                if (resourceDictionary.ContainsKey(styleKey))
                {
                    style = resourceDictionary[styleKey] as Style;
                }
            }
            return style;
        }
       
        private void SwapStyles(Button button)
        {
            //Application-scope resource
            var coloredButtonStyle = GetStyleFromResourceDictionary(Application.Current.Resources, "ColoredButtonStyle");

            //Page-scope resource
            var ellipsisButtonStyle = GetStyleFromResourceDictionary(Resources, "OrangeButtonStyle");

            Style newStyle;
            if(button.Style == coloredButtonStyle)
            {
                newStyle = ellipsisButtonStyle;
            }
            else
            {
                newStyle = coloredButtonStyle;
            }

            button.Style = newStyle;
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            MyButton myButton = sender as MyButton;
            if(myButton != null)
            {
                SwapStyles(myButton);
            }
        }
    }
}
