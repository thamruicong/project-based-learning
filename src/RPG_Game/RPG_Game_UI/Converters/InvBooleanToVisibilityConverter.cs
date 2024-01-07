using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RPG_Game_UI.Converters
{
    // copied from https://www.dotnetmirror.com/articles/wpf/107/wpf-visibility-converter-example-using-ivalueconverter
    public class InvBooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool visibility = false;

            if (value is bool v)
            {
                visibility = v;
            }

            return visibility ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = (Visibility)value;

            return visibility == Visibility.Hidden;
        }
    }
}