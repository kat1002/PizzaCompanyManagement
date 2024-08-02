using BusinessObjects;
using System.Globalization;
using System.Windows.Data;

namespace WPFApp.Utilities
{
    public class ToppingsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ICollection<Topping> toppings && toppings.Any())
            {
                return string.Join(", ", toppings.Select(t => t.Name));
            }
            return "No Toppings";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
