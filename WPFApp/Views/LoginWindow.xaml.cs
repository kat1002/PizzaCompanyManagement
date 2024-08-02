using System.Windows;
using WPFApp.ViewModels;

namespace WPFApp.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            LoginViewModel vm = new LoginViewModel();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());
        }
    }
}
