using System.Windows.Controls;
using WPFApp.ViewModels;

namespace WPFApp.Views
{
    /// <summary>
    /// Interaction logic for ConfirmOrder.xaml
    /// </summary>
    public partial class ConfirmOrder : UserControl
    {
        public ConfirmOrder()
        {
            InitializeComponent();
            DataContext = new ConfirmOrderViewModel();
        }
    }
}
