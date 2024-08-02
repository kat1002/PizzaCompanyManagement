using System.Windows.Controls;
using WPFApp.ViewModels;

namespace WPFApp.Views
{
    /// <summary>
    /// Interaction logic for UserList.xaml
    /// </summary>
    public partial class UserList : UserControl
    {
        public UserList()
        {
            InitializeComponent();
            DataContext = new UserListViewModel();
        }
    }
}
