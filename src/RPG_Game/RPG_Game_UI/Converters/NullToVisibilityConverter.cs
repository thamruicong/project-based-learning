using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RPG_Game_UI.Converters
{
    // copied from https://stackoverflow.com/questions/21939667/nulltovisibilityconverter-make-visible-if-not-null
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is null ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); // not needed
        }
    }
}