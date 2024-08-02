using System.Windows.Controls;
using WPFApp.ViewModels;

namespace WPFApp.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
            DataContext = new DashboardViewModel();
        }
    }
}
