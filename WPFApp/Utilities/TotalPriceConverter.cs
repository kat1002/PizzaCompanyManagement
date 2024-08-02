using BusinessObjects;
using System.Globalization;
using System.Windows.Data;

namespace WPFApp.Utilities
{
    public class TotalPriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal totalPrice = 0;
            if (value is Order order)
            {
                // Calculate total price based on associated DrinkOrders
                if (order.DrinkOrders != null)
                {
                    totalPrice += order.DrinkOrders.Sum(d => d.Quantity * d.Drink.Price);
                }

                // Calculate total price based on associated PizzaOrders
                if (order.PizzaOrders != null)
                {
                    totalPrice += order.PizzaOrders.Sum(p => p.Quantity * p.Pizza.Price);
                }

                // Calculate total price based on associated SideOrders
                if (order.SideOrders != null)
                {
                    totalPrice += order.SideOrders.Sum(s => s.Quantity * s.Side.Price);
                }
            }
            return $"${totalPrice}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
