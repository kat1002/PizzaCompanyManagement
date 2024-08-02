using System.Windows.Input;
using WPFApp.Utilities;

namespace WPFApp.ViewModels
{
    public class NavigationViewModel : ViewModel
    {
        private object currentView;
        public object CurrentView
        {
            get { return currentView; }
            set => SetField(ref currentView, value);
        }

        public ICommand DashboardCommand { get; set; }
        public ICommand InventoryCommand { get; set; }
        public ICommand OrderListCommand { get; set; }
        public ICommand PlaceOrderCommand { get; set; }
        public ICommand ReportCommand { get; set; }
        public ICommand ConfirmOrderCommand { get; set; }
        public ICommand OrderDetailCommand { get; set; }

        private void Dashboard(object obj) => CurrentView = new DashboardViewModel();
        private void Inventory(object obj) => CurrentView = new InventoryViewModel();
        private void OrderList(object obj) => CurrentView = new OrderListViewModel();
        private void PlaceOrder(object obj) => CurrentView = new PlaceOrderViewModel();
        private void Report(object obj) => CurrentView = new ReportViewModel();
        private void OrderDetail(object obj) => CurrentView = new OrderDetailViewModel();
        private void ConfirmOrder(object obj) => CurrentView = new ConfirmOrderViewModel();

        public NavigationViewModel()
        {
            DashboardCommand = new RelayCommand(Dashboard);
            InventoryCommand = new RelayCommand(Inventory);
            OrderListCommand = new RelayCommand(OrderList);
            PlaceOrderCommand = new RelayCommand(PlaceOrder);
            ReportCommand = new RelayCommand(Report);
            OrderDetailCommand = new RelayCommand(OrderDetail);
            ConfirmOrderCommand = new RelayCommand(ConfirmOrder);

            // start up 
            CurrentView = new PlaceOrderViewModel();
        }

    }
}
