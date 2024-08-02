using System.Windows;
using System.Windows.Controls;

namespace WPFApp.Views
{
    public partial class PlaceOrder : UserControl
    {
        public PlaceOrder()
        {
            InitializeComponent();
        }

        private void Pizza_Click(object sender, RoutedEventArgs e)
        {
            PizzaPanel.Visibility = Visibility.Visible;
            DrinksPanel.Visibility = Visibility.Collapsed;
            SidesPanel.Visibility = Visibility.Collapsed;
        }

        private void Drinks_Click(object sender, RoutedEventArgs e)
        {
            PizzaPanel.Visibility = Visibility.Collapsed;
            DrinksPanel.Visibility = Visibility.Visible;
            SidesPanel.Visibility = Visibility.Collapsed;
        }

        private void Sides_Click(object sender, RoutedEventArgs e)
        {
            PizzaPanel.Visibility = Visibility.Collapsed;
            DrinksPanel.Visibility = Visibility.Collapsed;
            SidesPanel.Visibility = Visibility.Visible;
        }

    }
}
