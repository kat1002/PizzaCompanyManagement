using BusinessObjects;
using Services;
using System.Windows.Input;
using WPFApp.Utilities;

namespace WPFApp.ViewModels
{
    public class OrderDetailViewModel : ViewModel
    {
        private readonly OrderService orderService;

        private Order order;
        public Order Order
        {
            get => order;
            set
            {
                SetField(ref order, value);
            }
        }

        public ICommand BackCommand { get; set; }


        public OrderDetailViewModel()
        {
            orderService = new OrderService(); // Ideally, you should use dependency injection  

            BackCommand = new RelayCommand(Back);
        }

        public void ShowOrder(object c)
        {
            order = (Order)c;
        }
        private void Back(object c)
        {

        }
    }
}
