using System.Windows.Input;
using WPFApp.Services;
using WPFApp.Utilities;
using WPFApp.Views;

namespace WPFApp.ViewModels
{
    public class CustomerWindowViewModel : ViewModel
    {
        public Action CloseAction { get; set; }

        private WindowService windowService;

        public ICommand LogoutCommand { get; set; }
        public CustomerWindowViewModel()
        {
            LogoutCommand = new RelayCommand(Logout);
            windowService = new WindowService();

            PlaceOrderViewModel = new PlaceOrderViewModel();
            ConfirmOrderViewModel = new ConfirmOrderViewModel();
            OrderListViewModel = new OrderListViewModel();

            PlaceOrderViewModel.PizzaAdded += ConfirmOrderViewModel.AddPizza;
            PlaceOrderViewModel.DrinkAdded += ConfirmOrderViewModel.AddDrink;
            PlaceOrderViewModel.SideAdded += ConfirmOrderViewModel.AddSide;

            ConfirmOrderViewModel.PlaceOrder += OrderListViewModel.RefreshOrders;
        }
        public PlaceOrderViewModel PlaceOrderViewModel { get; }
        public ConfirmOrderViewModel ConfirmOrderViewModel { get; }
        public OrderListViewModel OrderListViewModel { get; }

        public void Logout(object c)
        {
            windowService.ShowWindow<LoginWindow>();

            CloseAction();
        }
    }
}
