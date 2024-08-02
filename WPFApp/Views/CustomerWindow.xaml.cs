using System.Windows;
using WPFApp.ViewModels;

namespace WPFApp.Views
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public CustomerWindow()
        {
            InitializeComponent();
            CustomerWindowViewModel vm = new CustomerWindowViewModel();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());
        }

        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            PlaceOrder.Visibility = Visibility.Visible;
            ConfirmOrder.Visibility = Visibility.Collapsed;
            Profile.Visibility = Visibility.Collapsed;
            OrderList.Visibility = Visibility.Collapsed;
        }

        private void ConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            PlaceOrder.Visibility = Visibility.Collapsed;
            ConfirmOrder.Visibility = Visibility.Visible;
            Profile.Visibility = Visibility.Collapsed;
            OrderList.Visibility = Visibility.Collapsed;
        }
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            PlaceOrder.Visibility = Visibility.Collapsed;
            ConfirmOrder.Visibility = Visibility.Collapsed;
            Profile.Visibility = Visibility.Visible;
            OrderList.Visibility = Visibility.Collapsed;
        }

        private void OrderList_Click(object sender, RoutedEventArgs e)
        {
            PlaceOrder.Visibility = Visibility.Collapsed;
            ConfirmOrder.Visibility = Visibility.Collapsed;
            Profile.Visibility = Visibility.Collapsed;
            OrderList.Visibility = Visibility.Visible;
        }
    }
}
