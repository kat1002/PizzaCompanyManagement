using BusinessObjects;
using Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPFApp.Services;
using WPFApp.Utilities;

namespace WPFApp.ViewModels
{
    public class ConfirmOrderViewModel : ViewModel
    {
        public event Action PlaceOrder;

        private OrderService orderService;

        private string totalPrice;
        public string TotalPrice
        {
            get { return totalPrice; }
            set
            {
                SetField(ref totalPrice, value);
            }
        }

        private string shippingAddress;
        public string ShippingAddress
        {
            get { return shippingAddress; }
            set
            {
                SetField(ref shippingAddress, value);
            }
        }

        private PizzaOrder selectedPizza;
        public PizzaOrder SelectedPizza
        {
            get { return selectedPizza; }
            set
            {
                if (selectedPizza != value)
                {
                    SelectedDrink = null;
                    SelectedSide = null;
                    SetField(ref selectedPizza, value);
                }
            }
        }

        private ObservableCollection<PizzaOrder> pizzas;
        public ObservableCollection<PizzaOrder> Pizzas
        {
            get { return pizzas; }
            set
            {
                pizzas = value;
                SetField(ref pizzas, value);
            }
        }
        private DrinkOrder selectedDrink;
        public DrinkOrder SelectedDrink
        {
            get { return selectedDrink; }
            set
            {
                if (selectedDrink != value)
                {
                    SelectedPizza = null;
                    SelectedSide = null;
                    SetField(ref selectedDrink, value);
                }
            }
        }
        private ObservableCollection<DrinkOrder> drinks;
        public ObservableCollection<DrinkOrder> Drinks
        {
            get { return drinks; }
            set
            {
                drinks = value;
                SetField(ref drinks, value);
            }
        }
        private SideOrder selectedSide;
        public SideOrder SelectedSide
        {
            get { return selectedSide; }
            set
            {
                if (selectedSide != value)
                {
                    SelectedPizza = null;
                    SelectedDrink = null;
                    SetField(ref selectedSide, value);
                }
            }
        }
        private ObservableCollection<SideOrder> sides;
        public ObservableCollection<SideOrder> Sides
        {
            get { return sides; }
            set
            {
                sides = value;
                SetField(ref sides, value);
            }
        }

        private bool isPopupOpen;
        public bool IsPopupOpen
        {
            get => isPopupOpen;
            set => SetField(ref isPopupOpen, value);
        }

        public ICommand IncreaseCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand DecreaseCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }
        public ICommand AddressCommand { get; set; }
        public ICommand ClosePopupCommand { get; set; }
        public ConfirmOrderViewModel()
        {
            orderService = new OrderService();

            Pizzas = new ObservableCollection<PizzaOrder>();
            Drinks = new ObservableCollection<DrinkOrder>();
            Sides = new ObservableCollection<SideOrder>();

            ClearCommand = new RelayCommand(ClearOrder);
            ConfirmCommand = new RelayCommand(ConfirmOrder);
            IncreaseCommand = new RelayCommand(IncreaseQuantity);
            DecreaseCommand = new RelayCommand(DecreaseQuantity);
            DeleteCommand = new RelayCommand(DeleteItem);
            AddressCommand = new RelayCommand(OpenPopup);
            ClosePopupCommand = new RelayCommand(ClosePopup);
        }
        private void OpenPopup(object c)
        {
            IsPopupOpen = true;
        }

        private void ClosePopup(object c)
        {
            IsPopupOpen = false;
        }

        public void AddPizza(Pizza pizza)
        {
            var pizzaCheck = Pizzas.FirstOrDefault(po => po.Pizza.Equals(pizza));
            if (pizzaCheck != null)
            {
                pizzaCheck.Quantity += 1;
            }
            else
                Pizzas.Add(new PizzaOrder() { Pizza = pizza, Quantity = 1 });
            CalculateTotal();
        }
        public void AddDrink(IEnumerable<Drink> drinkList)
        {
            foreach (var item in drinkList)
            {
                var drinkCheck = Drinks.FirstOrDefault(d => d.Drink.Name.Equals(item.Name));
                if (drinkCheck != null)
                {
                    drinkCheck.Quantity += 1;
                }
                else
                {
                    Drinks.Add(new DrinkOrder() { Drink = item, Quantity = 1 });
                }
            }
            CalculateTotal();
        }
        public void AddSide(IEnumerable<Side> sideList)
        {
            foreach (var item in sideList)
            {
                var sideCheck = Sides.FirstOrDefault(d => d.Side.Name.Equals(item.Name));
                if (sideCheck != null)
                {
                    sideCheck.Quantity += 1;
                }
                else
                {
                    Sides.Add(new SideOrder() { Side = item, Quantity = 1 });
                }
            }
            CalculateTotal();
        }
        private void ClearOrder(object c)
        {
            Pizzas.Clear();
            Drinks.Clear();
            Sides.Clear();
            CalculateTotal();
        }

        private void ConfirmOrder(object c)
        {
            bool canAdd = true;
            if (string.IsNullOrEmpty(ShippingAddress))
            {
                MessageBox.Show("You must enter shipping address to create new order");
                canAdd = false;
            }
            else if (Pizzas.Count == 0 && Drinks.Count == 0 && Sides.Count == 0)
            {
                MessageBox.Show("You cannot create new orders before adding dishes");
                canAdd = false;
            }

            var newOrder = new Order
            {
                Customer = CurrentSession.Instance.LoggedInCustomer,
                OrderDate = DateOnly.FromDateTime(DateTime.Now),
                OrderTime = TimeOnly.FromDateTime(DateTime.Now),
                ShippingAddress = ShippingAddress,
                PizzaOrders = Pizzas.ToList(),
                DrinkOrders = Drinks.ToList(),
                SideOrders = Sides.ToList()
            };
            if (canAdd)
            {
                orderService.AddOrder(newOrder);
                ClearOrder(c);
                PlaceOrder?.Invoke();
            }
            ClosePopup(new object());

        }
        private void IncreaseQuantity(object c)
        {
            if (selectedDrink == null && selectedPizza == null && selectedSide == null)
            {
                MessageBox.Show("You must choose one item");
            }
            if (SelectedSide != null)
            {
                SelectedSide.Quantity += 1;
            }
            else if (SelectedDrink != null)
            {
                SelectedDrink.Quantity += 1;
            }
            else if (SelectedPizza != null)
            {
                SelectedPizza.Quantity += 1;
            }
            CalculateTotal();
        }
        private void DecreaseQuantity(object c)
        {
            if (selectedDrink == null && selectedPizza == null && selectedSide == null)
            {
                MessageBox.Show("You must choose one item");
            }
            if (SelectedSide != null)
            {
                if (SelectedSide.Quantity > 1)
                {
                    SelectedSide.Quantity -= 1;
                }
                else
                {
                    MessageBox.Show("You cannot decrease the quantity <= 0");
                }
            }
            else if (SelectedDrink != null)
            {
                if (SelectedDrink.Quantity > 1)
                {
                    SelectedDrink.Quantity -= 1;

                }
                else MessageBox.Show("You cannot decrease the quantity <= 0");
            }
            else if (SelectedPizza != null)
            {
                if (SelectedPizza.Quantity > 1)
                {
                    SelectedPizza.Quantity -= 1;
                }
                else MessageBox.Show("You cannot decrease the quantity <= 0");
            }
            CalculateTotal();
        }
        private void DeleteItem(object c)
        {
            if (selectedDrink == null && selectedPizza == null && selectedSide == null)
            {
                MessageBox.Show("You must choose one item");
            }
            if (SelectedSide != null)
            {
                Sides.Remove(SelectedSide);
            }
            else if (SelectedDrink != null)
            {
                Drinks.Remove(SelectedDrink);
            }
            else if (SelectedPizza != null)
            {
                Pizzas.Remove(SelectedPizza);
            }
            CalculateTotal();
        }

        void CalculateTotal()
        {
            decimal total = 0;
            // Calculate total price based on associated DrinkOrders
            if (Drinks != null)
            {
                total += Drinks.Sum(d => d.Quantity * d.Drink.Price);
            }

            // Calculate total price based on associated PizzaOrders
            if (Pizzas != null)
            {
                total += Pizzas.Sum(p => p.Quantity * p.Pizza.Price);
            }

            // Calculate total price based on associated SideOrders
            if (Sides != null)
            {
                total += Sides.Sum(s => s.Quantity * s.Side.Price);
            }
            TotalPrice = $"${total}";
        }
    }
}
