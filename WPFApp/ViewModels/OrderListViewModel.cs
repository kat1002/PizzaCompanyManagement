using BusinessObjects;
using Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPFApp.Services;
using WPFApp.Utilities;

namespace WPFApp.ViewModels
{
    public class OrderListViewModel : ViewModel
    {
        private readonly OrderService orderService;

        private Order selectedOrder;
        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                if (selectedOrder != value)
                {
                    SetField(ref selectedOrder, value);
                }
            }
        }

        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set
            {
                SetField(ref _orders, value);
            }
        }

        private bool isOrderListVisible = true;
        public bool IsOrderListVisible
        {
            get => isOrderListVisible;
            set
            {
                SetField(ref isOrderListVisible, value);
            }
        }

        private bool isOrderDetailVisible = false;
        public bool IsOrderDetailVisible
        {
            get => isOrderDetailVisible;
            set
            {
                SetField(ref isOrderDetailVisible, value);
            }
        }

        public ICommand BackCommand { get; set; }
        public ICommand ViewCommand { get; set; }


        public OrderListViewModel()
        {
            orderService = new OrderService();
            LoadOrders();

            ViewCommand = new RelayCommand(ShowOrderDetail);
            BackCommand = new RelayCommand(Back);
        }

        private void LoadOrders()
        {
            if (CurrentSession.Instance.LoggedInCustomer == null)
            {
                var orders = orderService.GetAll();
                Orders = new ObservableCollection<Order>(orders);
            }
            else
            {
                var orders = orderService.GetCustomerOrders(CurrentSession.Instance.LoggedInCustomer.Id);
                Orders = new ObservableCollection<Order>(orders);
            }
        }
        public void RefreshOrders()
        {
            var orders = orderService.GetCustomerOrders(CurrentSession.Instance.LoggedInCustomer.Id);
            Orders = new ObservableCollection<Order>(orders);
        }

        private void ShowOrderDetail(object c)
        {
            if (selectedOrder == null) MessageBox.Show("You must choose one order to view");
            else
            {
                IsOrderDetailVisible = true;
                IsOrderListVisible = false;
            }
        }
        private void Back(object c)
        {
            IsOrderDetailVisible = false;
            IsOrderListVisible = true;
            SelectedOrder = null;
        }
    }
}
