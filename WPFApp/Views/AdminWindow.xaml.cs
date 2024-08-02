using System.Windows;
using WPFApp.ViewModels;

namespace WPFApp.Views
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            AdminWindowViewModel vm = new AdminWindowViewModel();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());

        }

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            Dashboard.Visibility = Visibility.Visible;
            Order.Visibility = Visibility.Collapsed;
            User.Visibility = Visibility.Collapsed;
            Inventory.Visibility = Visibility.Collapsed;
            Report.Visibility = Visibility.Collapsed;
            ProductList.Visibility = Visibility.Collapsed;
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            Dashboard.Visibility = Visibility.Collapsed;
            Order.Visibility = Visibility.Visible;
            User.Visibility = Visibility.Collapsed;
            Inventory.Visibility = Visibility.Collapsed;
            Report.Visibility = Visibility.Collapsed;
            ProductList.Visibility = Visibility.Collapsed;  
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            Dashboard.Visibility = Visibility.Collapsed;
            Order.Visibility = Visibility.Collapsed;
            User.Visibility = Visibility.Visible;
            Inventory.Visibility = Visibility.Collapsed;
            Report.Visibility = Visibility.Collapsed;
            ProductList.Visibility = Visibility.Collapsed;  
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            Dashboard.Visibility = Visibility.Collapsed;
            Order.Visibility = Visibility.Collapsed;
            User.Visibility = Visibility.Collapsed;
            Inventory.Visibility = Visibility.Collapsed;
            Report.Visibility = Visibility.Visible;
            ProductList.Visibility = Visibility.Collapsed;  
        }
        private void Product_Click(object sender, RoutedEventArgs e)
        {
            Dashboard.Visibility = Visibility.Collapsed;
            Order.Visibility = Visibility.Collapsed;
            User.Visibility = Visibility.Collapsed;
            Inventory.Visibility = Visibility.Collapsed;
            Report.Visibility = Visibility.Collapsed;
            ProductList.Visibility = Visibility.Visible;
        }

    }
}
