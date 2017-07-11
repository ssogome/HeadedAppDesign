using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HeadedAppDesign
{
    class MyButton: Button
    {
        private const string defaultContent = "My content";
        private const double defaultMargin = 10.0;

        public MyButton()
        {
            Content = defaultContent;
            Margin = new Thickness(defaultMargin);
        }
    }
}
