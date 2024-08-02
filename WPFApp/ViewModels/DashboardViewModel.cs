using BusinessObjects;
using Services;
using System.Collections.ObjectModel;


namespace WPFApp.ViewModels
{
    public class DashboardViewModel : ViewModel
    {
        private readonly OrderService orderService;
        private ObservableCollection<Order> _orders;

        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                SetField(ref _orders, value);
                UpdateOrderStatistics();
            }
        }

        private int _numberOfOrders;
        public int NumberOfOrders
        {
            get => _numberOfOrders;
            set
            {
                _numberOfOrders = value;
                SetField(ref _numberOfOrders, value);
            }
        }

        private string _totalOrderPrice;
        public string TotalOrderPrice
        {
            get => _totalOrderPrice;
            set
            {
                _totalOrderPrice = value;
                SetField(ref _totalOrderPrice, value);
            }
        }

        public DashboardViewModel()
        {
            orderService = new OrderService();
            LoadOrders();
        }

        private void LoadOrders()
        {
            var orders = orderService.GetAll();
            Orders = new ObservableCollection<Order>(orders);
        }

        private void UpdateOrderStatistics()
        {
            NumberOfOrders = Orders.Count;
            var total = Orders.Sum(order =>
                order.DrinkOrders.Sum(d => d.Quantity * d.Drink.Price) +
                order.PizzaOrders.Sum(p => p.Quantity * p.Pizza.Price) +
                order.SideOrders.Sum(s => s.Quantity * s.Side.Price)
            );
            TotalOrderPrice = $"${total}";
        }
    }
}
