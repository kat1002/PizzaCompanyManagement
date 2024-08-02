using BusinessObjects;
using Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPFApp.Utilities;
using WPFApp.Views;


namespace WPFApp.ViewModels
{
    public class UserListViewModel : ViewModel
    {

        private readonly CustomerService customerService;
        private ObservableCollection<Customer> _customers;

        public ICommand DisableCommand { get; set; }
        public ICommand EnableCommand { get; set; }
        public ICommand DisableAdminCommand { get; set; }
        public ICommand EnableAdminCommand { get; set; }
        public ICommand ViewUserCommand { get; set; }


        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                SetField(ref _customers, value);
            }
        }

        private Customer selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                if (selectedCustomer != value)
                {
                    SetField(ref selectedCustomer, value);
                }
            }
        }

        public UserListViewModel()
        {
            customerService = new CustomerService();
            LoadCustomers();

            DisableCommand = new RelayCommand(DisableCustomer);
            EnableCommand = new RelayCommand(EnableCustomer);
            DisableAdminCommand = new RelayCommand(DisableAdminCustomer);
            EnableAdminCommand = new RelayCommand(EnableAdminCustomer);
            ViewUserCommand = new RelayCommand(ViewUser);
        }

        private void LoadCustomers()
        {
            var customers = customerService.GetAll();
            Customers = new ObservableCollection<Customer>(customers);
        }

        private void DisableCustomer(object c)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Disable Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                customerService.DisableCustomer(SelectedCustomer);
            }
        }
        private void EnableCustomer(object c)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Enable Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                customerService.EnableCustomer(SelectedCustomer);
            }
        }

        private void DisableAdminCustomer(object c)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Disable Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                customerService.DisableAdminCustomer(SelectedCustomer);
            }
        }
        private void EnableAdminCustomer(object c)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Enable Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                customerService.EnableAdminCustomer(SelectedCustomer);
            }
        }

        private void ViewUser(object c) {
            UserProfile _userProfileWindow = new UserProfile(SelectedCustomer);
            _userProfileWindow.Show();
        }
    }
}
