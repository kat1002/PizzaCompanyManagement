using BusinessObjects;
using Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPFApp.Utilities;

namespace WPFApp.ViewModels
{
    public class ReportViewModel : ViewModel
    {
        private OrderService orderService;
        private DateTime _startDate = DateTime.Today;
        private DateTime _endDate = DateTime.Today;
        private ObservableCollection<Order> orders;

        private string _totalOrderPrice;
        public string TotalOrderPrice
        {
            get => _totalOrderPrice;
            set
            {
                SetField(ref _totalOrderPrice, value);
            }
        }

        public DateTime StartDate { get => _startDate; set => SetField(ref _startDate, value); }
        public DateTime EndDate { get => _endDate; set => SetField(ref _endDate, value); }
        public ICommand Filter { get; set; }
        public ObservableCollection<Order> Reports { get => orders; set => SetField(ref orders, value); }
        public void DoFilter(object c)
        {
            Reports = new ObservableCollection<Order>(orderService.GetOrdersByDateRange(StartDate, EndDate));
            UpdateOrderStatistics();
        }
        public ReportViewModel()
        {
            orderService = new OrderService();
            //Reports = new ObservableCollection<Order>(.GetRoomBookings());
            Filter = new RelayCommand(DoFilter);
        }
        private void UpdateOrderStatistics()
        {
            var total = Reports.Sum(order =>
                order.DrinkOrders.Sum(d => d.Quantity * d.Drink.Price) +
                order.PizzaOrders.Sum(p => p.Quantity * p.Pizza.Price) +
                order.SideOrders.Sum(s => s.Quantity * s.Side.Price)
            );
            TotalOrderPrice = $"${total}";
        }
    }
}
