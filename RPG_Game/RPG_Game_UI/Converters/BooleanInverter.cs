using System;
using System.Globalization;
using System.Windows.Data;

// copied from https://stackoverflow.com/questions/1039636/how-to-bind-inverse-boolean-properties-in-wpf
namespace RPG_Game_UI.Converters
{
    public class BooleanInverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(bool))
                throw new InvalidOperationException("The target must be a boolean");
            
            return !(bool) value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion IValueConverter Members
    }
}