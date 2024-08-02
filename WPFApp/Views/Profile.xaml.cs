using System.Windows.Controls;
using WPFApp.Services;
using WPFApp.ViewModels;
using BusinessObjects;

namespace WPFApp.Views
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        public Profile()
        {
            InitializeComponent();
            DataContext = new ProfileViewModel(CurrentSession.Instance.LoggedInCustomer);
        }

    }
}
