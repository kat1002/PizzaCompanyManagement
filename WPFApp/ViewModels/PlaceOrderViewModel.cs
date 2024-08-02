using BusinessObjects;
using Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPFApp.Utilities;

namespace WPFApp.ViewModels
{
    public class PlaceOrderViewModel : ViewModel
    {
        public event Action<Pizza> PizzaAdded;
        public event Action<IEnumerable<Drink>> DrinkAdded;
        public event Action<IEnumerable<Side>> SideAdded;

        private readonly SizeService sizeService;
        private readonly CrustService crustService;
        private readonly ToppingService toppingService;
        private readonly DrinkService drinkService;
        private readonly SideService sideService;

        public ObservableCollection<BusinessObjects.Size> Sizes { get; set; }
        public ObservableCollection<Crust> Crusts { get; set; }
        public ObservableCollection<Topping> Toppings { get; set; }
        public ObservableCollection<Drink> Drinks { get; set; }
        public ObservableCollection<Side> Sides { get; set; }

        private BusinessObjects.Size selectedSize;
        public BusinessObjects.Size SelectedSize
        {
            get => selectedSize;
            set
            {
                SetField(ref selectedSize, value);
            }
        }

        private Crust selectedCrust;
        public Crust SelectedCrust
        {
            get => selectedCrust;
            set
            {
                SetField(ref selectedCrust, value);
            }
        }

        public ObservableCollection<Topping> SelectedToppings { get; set; }
        public ObservableCollection<Drink> SelectedDrinks { get; set; }
        public ObservableCollection<Side> SelectedSides { get; set; }

        public ICommand SizeCommand { get; set; }
        public ICommand CrustCommand { get; set; }
        public ICommand ToppingCommand { get; set; }
        public ICommand DrinkCommand { get; set; }
        public ICommand SideCommand { get; set; }
        public ICommand AddPizzaCommand { get; set; }
        public ICommand AddDrinkCommand { get; set; }
        public ICommand AddSideCommand { get; set; }
        public PlaceOrderViewModel()
        {

            sizeService = new SizeService();
            crustService = new CrustService();
            toppingService = new ToppingService();
            drinkService = new DrinkService();
            sideService = new SideService();

            SizeCommand = new RelayCommand(SetSelectedSize);
            CrustCommand = new RelayCommand(SetSelectedCrust);
            ToppingCommand = new RelayCommand(SetSelectedTopping);
            DrinkCommand = new RelayCommand(SetSelectedDrink);
            SideCommand = new RelayCommand(SetSelectedSide);

            SelectedToppings = new ObservableCollection<Topping>();
            SelectedDrinks = new ObservableCollection<Drink>();
            SelectedSides = new ObservableCollection<Side>();

            AddPizzaCommand = new RelayCommand(AddPizza);
            AddDrinkCommand = new RelayCommand(AddDrink);
            AddSideCommand = new RelayCommand(AddSide);

            LoadData();
        }

        private void LoadData()
        {
            Sizes = new ObservableCollection<BusinessObjects.Size>(sizeService.GetAll().Select(p => new BusinessObjects.Size { Id = p.Id, Description = p.Description, Price = p.Price }));
            Crusts = new ObservableCollection<Crust>(crustService.GetAll().Select(c => new Crust { Id = c.Id, Type = c.Type }));
            Toppings = new ObservableCollection<Topping>(toppingService.GetAll().Select(t => new Topping { Id = t.Id, Name = t.Name, Price = t.Price }));
            Drinks = new ObservableCollection<Drink>(drinkService.GetAll().Select(d => new Drink { Id = d.Id, Name = d.Name, Price = d.Price }));
            Sides = new ObservableCollection<Side>(sideService.GetAll().Select(o => new Side { Id = o.Id, Name = o.Name, Price = o.Price }));
        }
        private void AddPizza(object c)
        {
            if (!CheckCanAddPizza()) return;

            var pizza = new Pizza
            {
                CrustId = SelectedCrust.Id,
                SizeId = SelectedSize.Id,
                Crust = SelectedCrust,
                Size = SelectedSize,
                Toppings = new List<Topping>(SelectedToppings)
            };

            // Calculate the price of the pizza
            pizza.Price = CalculatePizzaPrice(pizza);

            // Notify listeners that a pizza has been added
            PizzaAdded?.Invoke(pizza);

            MessageBox.Show("Add pizza successfully");

        }

        private void AddDrink(object c)
        {

            if (!CheckCanAddDrinks()) return;

            DrinkAdded?.Invoke(SelectedDrinks);

            MessageBox.Show("Add drinks successfully");
        }

        private void AddSide(object c)
        {
            if (!CheckCanAddSides()) return;

            SideAdded?.Invoke(SelectedSides);


            MessageBox.Show("Add sides successfully");
        }


        private void SetSelectedSize(object parameter)
        {
            SelectedSize = (BusinessObjects.Size)parameter;
        }
        private void SetSelectedCrust(object parameter)
        {
            SelectedCrust = (Crust)parameter;
        }
        private void SetSelectedTopping(object parameter)
        {
            var values = (object[])parameter;
            var topping = (Topping)values[0];
            bool check = (bool)values[1];
            if (check)
            {
                SelectedToppings.Add(topping);
            }
            else
            {
                SelectedToppings.Remove(topping);
            }
        }
        private void SetSelectedDrink(object parameter)
        {
            var values = (object[])parameter;
            var drink = (Drink)values[0];
            bool check = (bool)values[1];
            if (check)
            {
                SelectedDrinks.Add(drink);
            }
            else
            {
                SelectedDrinks.Remove(drink);
            }
        }
        private void SetSelectedSide(object parameter)
        {
            var values = (object[])parameter;
            var side = (Side)values[0];
            bool check = (bool)values[1];
            if (check)
            {
                SelectedSides.Add(side);
            }
            else
            {
                SelectedSides.Remove(side);
            }
        }
        private decimal CalculatePizzaPrice(Pizza pizza)
        {
            decimal price = pizza.Size.Price;
            foreach (var topping in pizza.Toppings)
            {
                price += topping.Price;
            }
            return price;
        }
        private bool CheckCanAddPizza()
        {
            if (SelectedCrust == null)
            {
                MessageBox.Show("You must choose one crust type");
                return false;
            }
            if (SelectedSize == null)
            {
                MessageBox.Show("You must choose one size type");
                return false;
            }
            if (SelectedToppings.Count == 0)
            {
                MessageBox.Show("You must choose at least one topping");
                return false;
            }
            return true;
        }
        private bool CheckCanAddDrinks()
        {
            if (SelectedDrinks.Count == 0)
            {
                MessageBox.Show("You must choose at least one drink");
                return false;
            }
            return true;
        }
        private bool CheckCanAddSides()
        {
            if (SelectedSides.Count == 0)
            {
                MessageBox.Show("You must choose at least one side");
                return false;
            }
            return true;
        }
    }
}

