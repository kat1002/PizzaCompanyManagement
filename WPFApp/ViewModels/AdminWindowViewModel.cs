using System.Windows.Input;
using WPFApp.Services;
using WPFApp.Utilities;
using WPFApp.Views;

namespace WPFApp.ViewModels
{
    public class AdminWindowViewModel : ViewModel
    {
        public Action CloseAction { get; set; }

        private WindowService windowService;
        public ICommand LogoutCommand { get; set; }
        public AdminWindowViewModel()
        {
            windowService = new WindowService();

            LogoutCommand = new RelayCommand(Logout);
            OrderListViewModel = new OrderListViewModel();
        }

        private void Logout(object c)
        {
            windowService.ShowWindow<LoginWindow>();

            CloseAction();
        }
        public OrderListViewModel OrderListViewModel { get; }
    }
}
