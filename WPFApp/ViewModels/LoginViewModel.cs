using BusinessObjects;
using Microsoft.Extensions.Configuration;
using Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using WPFApp.Services;
using WPFApp.Utilities;
using WPFApp.Views;

namespace WPFApp.ViewModels
{
    public class LoginViewModel : ViewModel, IDataErrorInfo
    {
        public Action CloseAction { get; set; }

        private readonly IConfiguration configuration;
        private readonly string adminEmail;
        private readonly string adminPassword;

        private CustomerService customerService;
        private WindowService windowService;
        private string email;
        private string password;
        private string repassword;
        private string phoneNumber;
        private string address;
        private string fullname;
        private bool _isValidationTriggered;
        private bool _isLoginVisible = true;
        private bool _isSignupVisible = false;



        public ObservableCollection<Customer> customers { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand SignupCommand { get; set; }
        public ICommand ShowLoginCommand { get; set; }
        public ICommand ShowSignupCommand { get; set; }

        #region Properties
        public string Email
        {
            get => email;
            set
            {
                SetField(ref email, value);
            }
        }
        public string Password
        {
            get => password;
            set
            {
                SetField(ref password, value);
            }
        }
        public string Repassword
        {
            get => repassword;
            set
            {
                SetField(ref repassword, value);
            }
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                SetField(ref phoneNumber, value);
            }
        }
        public string Address
        {
            get => address;
            set
            {
                SetField(ref address, value);
            }
        }
        public string Fullname
        {
            get => fullname;
            set
            {
                SetField(ref fullname, value);
            }
        }

        public bool IsLoginVisible
        {
            get => _isLoginVisible;
            set
            {
                SetField(ref _isLoginVisible, value);
            }
        }

        public bool IsSignupVisible
        {
            get => _isSignupVisible;
            set
            {
                SetField(ref _isSignupVisible, value);
            }
        }
        #endregion

        #region Validation
        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (!_isValidationTriggered) return null;

                string result = null;

                switch (columnName)
                {
                    case nameof(Fullname):
                        if (string.IsNullOrWhiteSpace(Fullname))
                        {
                            result = "Name cannot be empty";
                        }
                        break;

                    case nameof(Address):
                        if (string.IsNullOrWhiteSpace(Address))
                        {
                            result = "Address cannot be empty";
                        }
                        break;

                    case nameof(Email):
                        if (string.IsNullOrWhiteSpace(Email))
                        {
                            result = "Email is required.";
                        }
                        else if (!IsValidEmail(Email))
                        {
                            result = "Invalid email format.";
                        }
                        break;

                    case nameof(PhoneNumber):
                        if (string.IsNullOrWhiteSpace(PhoneNumber))
                        {
                            result = "Phone number is required.";
                        }
                        else if (!IsValidPhoneNumber(PhoneNumber))
                        {
                            result = "Invalid phone number format.";
                        }
                        break;

                    case nameof(Password):
                        if (string.IsNullOrWhiteSpace(Password))
                        {
                            result = "Password number is required.";
                        }
                        else if (Password.Length < 5 || Password.Length > 30)
                        {
                            result = "Password must be longer than 5 characters";
                        }
                        break;

                    case nameof(Repassword):
                        if (string.IsNullOrWhiteSpace(Repassword))
                        {
                            result = "Re-entering password is required.";
                        }
                        else if (Repassword != Password)
                        {
                            result = "Passwords do not match.";
                        }
                        break;
                }

                return result;
            }
        }
        private bool IsValidEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            var phonePattern = @"^\d{10}$";
            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        #endregion


        public LoginViewModel()
        {
            email = "";
            password = "";

            // Load configuration
            configuration = ConfigurationHelper.GetConfiguration();
            adminEmail = configuration["AdminAccount:Email"];
            adminPassword = configuration["AdminAccount:Password"];

            customerService = new CustomerService();
            windowService = new WindowService();

            ShowLoginCommand = new RelayCommand(ShowLogin);
            ShowSignupCommand = new RelayCommand(ShowSignup);
            LoginCommand = new RelayCommand(Login);
            SignupCommand = new RelayCommand(Signup);
        }
        private void ShowLogin(object obj)
        {
            IsLoginVisible = true;
            IsSignupVisible = false;
            ResetInput();
        }

        private void ShowSignup(object obj)
        {
            IsLoginVisible = false;
            IsSignupVisible = true;
            ResetInput();
        }
        void Login(object c)
        {
            if (email.Equals(adminEmail) && password.Equals(adminPassword))
            {
                // Show the admin window
                windowService.ShowWindow<AdminWindow>();
                CloseAction();

                return;
            }
            Customer customer = customerService.GetCustomer(email, password);

            if (customer == null) {
                MessageBox.Show("Account does not exist!.");
                return;
            }

            if (!customer.State) {
                MessageBox.Show("You do not have permission!");
                return;
            }

            if (customer.IsAdmin)
            {
                CurrentSession.Instance.LoggedInCustomer = customer;
                windowService.ShowWindow<AdminWindow>();
                CloseAction();

                return;
            }
            else {
                CurrentSession.Instance.LoggedInCustomer = customer;
                windowService.ShowWindow<CustomerWindow>();
                CloseAction();
            }

        }
        void Signup(object c)
        {
            _isValidationTriggered = true;
            NotifyPropertyChanged(nameof(Fullname));
            NotifyPropertyChanged(nameof(Email));
            NotifyPropertyChanged(nameof(PhoneNumber));
            NotifyPropertyChanged(nameof(Address));
            NotifyPropertyChanged(nameof(Password));
            NotifyPropertyChanged(nameof(Repassword));

            if (string.IsNullOrEmpty(this[nameof(Fullname)]) &&
                string.IsNullOrEmpty(this[nameof(Email)]) &&
                string.IsNullOrEmpty(this[nameof(PhoneNumber)]) &&
                string.IsNullOrEmpty(this[nameof(Address)]) &&
                string.IsNullOrEmpty(this[nameof(Password)]) &&
                string.IsNullOrEmpty(this[nameof(Repassword)]))
            {
                Customer customer = new Customer();
                customer.Email = email;
                customer.Password = password;
                customer.Address = address;
                customer.Name = fullname;
                customer.Phone = phoneNumber;
                customer.State = true;

                if (customerService.CheckEmailDuplicated(Email))
                {
                    MessageBox.Show("Email is already in use !");
                }
                else if (customerService.CheckPhoneDuplicated(phoneNumber))
                {
                    MessageBox.Show("Phone is already in use !");
                }
                else
                {
                    customerService.AddCustomer(customer);
                    ShowLogin(new object());
                }
            }
            _isValidationTriggered = false;
        }
        private void ResetInput()
        {
            Fullname = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            Address = string.Empty;
            Password = string.Empty;
            Repassword = string.Empty;

            _isValidationTriggered = false;
            NotifyPropertyChanged(nameof(Fullname));
            NotifyPropertyChanged(nameof(Email));
            NotifyPropertyChanged(nameof(PhoneNumber));
            NotifyPropertyChanged(nameof(Address));
            NotifyPropertyChanged(nameof(Password));
            NotifyPropertyChanged(nameof(Repassword));
        }
    }
}
