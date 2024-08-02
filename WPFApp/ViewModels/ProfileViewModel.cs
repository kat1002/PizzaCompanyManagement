using BusinessObjects;
using Services;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using WPFApp.Utilities;

namespace WPFApp.ViewModels
{
    public class ProfileViewModel : ViewModel
    {
        private CustomerService customerService;
        private Customer currentCustomer;
        private string name;
        private string email;
        private string phoneNumber;
        private string address;
        private string password;
        private bool isPopupOpen;

        public string Name
        {
            get => name;
            set => SetField(ref name, value);
        }

        public string Email
        {
            get => email;
            set => SetField(ref email, value);
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetField(ref phoneNumber, value);
        }


        public string Password
        {
            get => password;
            set => SetField(ref password, value);
        }

        public string Address
        {
            get => address;
            set => SetField(ref address, value);
        }

        public bool IsPopupOpen
        {
            get => isPopupOpen;
            set => SetField(ref isPopupOpen, value);
        }

        public ICommand UpdateProfileCommand { get; set; }
        public ICommand ClosePopupCommand { get; set; }
        public ICommand SaveProfileCommand { get; set; }

        public ProfileViewModel(Customer c)
        {
            currentCustomer = c;
            customerService = new CustomerService();

            // Load customer data here (for simplicity, hardcoded values are used)
            Name = c.Name;
            Email = c.Email;
            PhoneNumber = c.Phone;
            Password = c.Password;
            Address = c.Address;

            UpdateProfileCommand = new RelayCommand(OpenPopup);
            ClosePopupCommand = new RelayCommand(ClosePopup);
            SaveProfileCommand = new RelayCommand(SaveProfile);

        }

        private void OpenPopup(object c)
        {
            IsPopupOpen = true;
        }

        private void ClosePopup(object c)
        {
            IsPopupOpen = false;
        }

        private void SaveProfile(object c)
        {
            // Save profile logic here
            if (!ValidateInput()) return;

            if (customerService.CheckEmailDuplicated(email) && currentCustomer.Email != email)
            {
                MessageBox.Show("This email is in used");
                ResetValue();
                return;
            }
            if (customerService.CheckPhoneDuplicated(phoneNumber) && currentCustomer.Phone != phoneNumber)
            {
                MessageBox.Show("This phone number is in used");
                ResetValue();
                return;
            }

            currentCustomer.Name = name;
            currentCustomer.Email = email;
            currentCustomer.Address = address;
            currentCustomer.Password = password;
            currentCustomer.Phone = phoneNumber;



            customerService.UpdateCustomer(currentCustomer);
            ClosePopup(new object());
        }
        private bool ValidateInput()
        {
            if (!ValidateString(name))
            {
                ResetValue();
                MessageBox.Show("Name is not valid");
                return false;
            }
            if (!ValidateString(address))
            {
                ResetValue();
                MessageBox.Show("Address is not valid");
                return false;
            }
            if (!ValidateEmail(email))
            {
                ResetValue();
                MessageBox.Show("Email is not valid");
                return false;
            }
            if (!ValidatePassword(password))
            {
                ResetValue();
                MessageBox.Show("Password is not valid");
                return false;
            }
            if (!ValiddatePhoneNumber(phoneNumber))
            {
                PhoneNumber = currentCustomer.Phone;
                MessageBox.Show("Phone is not valid");
                return false;
            }
            return true;
        }
        private bool ValidateString(string value)
        {

            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            string trimmedValue = value.Trim();
            bool hasLeadingOrTrailingSpaces = value != trimmedValue;
            bool hasMultipleSpacesBetweenWords = Regex.IsMatch(trimmedValue, @"\s{2,}");
            bool isLengthValid = trimmedValue.Length >= 4 && trimmedValue.Length <= 64;
            bool isMatchRegex = Regex.IsMatch(trimmedValue, @"^[a-zA-Z0-9 ]+$");

            bool isValid = !hasLeadingOrTrailingSpaces && !hasMultipleSpacesBetweenWords && isLengthValid && isMatchRegex;

            return isValid;
        }
        private bool ValidateEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
        private bool ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || Password.Length < 5 || Password.Length > 30)
                return false;
            return true;
        }
        private bool ValiddatePhoneNumber(string phoneNumber)
        {
            var phonePattern = @"^\d{10}$";
            return Regex.IsMatch(phoneNumber, phonePattern);
        }
        public void ResetValue()
        {
            Name = currentCustomer.Name;
            Email = currentCustomer.Email;
            PhoneNumber = currentCustomer.Phone;
            Password = currentCustomer.Password;
            Address = currentCustomer.Address;
        }
    }
}
