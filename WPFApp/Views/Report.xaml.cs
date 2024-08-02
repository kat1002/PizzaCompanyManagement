using System.Windows.Controls;
using WPFApp.ViewModels;

namespace WPFApp.Views
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : UserControl
    {
        public Report()
        {
            InitializeComponent();
            DataContext = new ReportViewModel();
        }

    }
}
