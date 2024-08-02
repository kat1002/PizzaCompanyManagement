using BusinessObjects;
using System.Globalization;
using System.Windows.Data;

namespace WPFApp.Utilities
{
    public class PizzaDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Pizza pizza)
            {
                string crust = pizza.Crust?.Type ?? "Unknown Crust";
                string size = pizza.Size?.Description ?? "Unknown Size";
                return $"{crust}, {size}";
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
