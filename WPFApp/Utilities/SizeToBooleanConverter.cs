using BusinessObjects;
using System.Globalization;
using System.Windows.Data;

namespace WPFApp.Utilities
{
    public class SizeToBooleanConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null || values[1] == null)
                return false;

            var selectedSize = values[0] as Size;
            var size = values[1] as Size;

            return selectedSize?.Id == size?.Id;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
