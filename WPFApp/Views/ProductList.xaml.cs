using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFApp.ViewModels;

namespace WPFApp.Views
{
    public partial class ProductList : UserControl
    {
        public ProductList()
        {
            InitializeComponent();
            var viewModel = new ProductListViewModel();

            DataContext = viewModel;
            viewModel.PropertyChanged += ViewModel_PropertyChanged;

        }
        private void UpdateDataGridColumns(IEnumerable<object> data)
        {
            list.Columns.Clear(); // Clear existing columns

            if (!data.Any())
                return;

            var firstItem = data.First();
            var properties = firstItem.GetType().GetProperties();

            foreach (var property in properties)
            {
                DataGridColumn column;
                if (property.PropertyType == typeof(bool))
                {
                    column = new DataGridCheckBoxColumn
                    {
                        Header = property.Name,
                        Binding = new Binding(property.Name)
                    };
                }
                else if (property.PropertyType == typeof(DateTime))
                {
                    column = new DataGridTextColumn
                    {
                        Header = property.Name,
                        Binding = new Binding(property.Name),
                        HeaderStringFormat = "MM/dd/yyyy"
                    };
                }
                else
                {
                    column = new DataGridTextColumn
                    {
                        Header = property.Name,
                        Binding = new Binding(property.Name)
                    };
                }
                list.Columns.Add(column);
            }
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ProductListViewModel.Data))
            {
                // Update columns when Data property changes
                var viewModel = DataContext as ProductListViewModel;
                if (viewModel != null)
                {
                    UpdateDataGridColumns(viewModel.Data);
                }
            }
        }
    }
}
