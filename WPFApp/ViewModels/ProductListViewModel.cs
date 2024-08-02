using BusinessObjects;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFApp.Services;
using WPFApp.Utilities;

namespace WPFApp.ViewModels
{
    class ProductListViewModel : ViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private CrustService crustService;
        private DrinkService drinkService;
        private SideService sideService;
        private SizeService sizeService;
        private ToppingService toppingService;

        private ObservableCollection<Crust> _crusts;
        public ObservableCollection<Crust> Crusts
        {
            get => _crusts;
            set
            {
                SetField(ref _crusts, value);
            }
        }

        private ObservableCollection<Topping> _toppings;
        public ObservableCollection<Topping> Toppings
        {
            get => _toppings;
            set
            {
                SetField(ref _toppings, value);
            }
        }

        private ObservableCollection<Drink> _drinks;
        public ObservableCollection<Drink> Drinks
        {
            get => _drinks;
            set
            {
                SetField(ref _drinks, value);
            }
        }

        private ObservableCollection<Side> _sides;
        public ObservableCollection<Side> Sides
        {
            get => _sides;
            set
            {
                SetField(ref _sides, value);
            }
        }

        private ObservableCollection<BusinessObjects.Size> _sizes;
        public ObservableCollection<BusinessObjects.Size> Sizes
        {
            get => _sizes;
            set
            {
                SetField(ref _sizes, value);
            }
        }

        public ICommand ShowCrustsCommand { get; set; }
        public ICommand ShowDrinksCommand { get; set; }
        public ICommand ShowSidesCommand { get; set; }
        public ICommand ShowSizesCommand { get; set; }
        public ICommand ShowToppingsCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand ViewCommand { get; set; }
        public ICommand UpdateProduct { get; set; }
        public ICommand CreateProduct { get; set; }

        private ObservableCollection<object> _data;
        public ObservableCollection<object> Data
        {
            get => _data;
            set => SetField(ref _data, value);
        }

        private object _selectedItem;
        public object SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                }

                UpdateTextBoxValues();
            }
        }

        private string _productName;
        public string ProductName
        {
            get => _productName;
            set => SetField(ref _productName, value);
        }

        private string _productPrice;
        public string ProductPrice
        {
            get => _productPrice;
            set => SetField(ref _productPrice, value);
        }

        public ProductListViewModel()
        {
            Load();

            ShowCrustsCommand = new RelayCommand(ShowCrustData);
            ShowDrinksCommand = new RelayCommand(ShowDrinkData);
            ShowSidesCommand = new RelayCommand(ShowSideData);
            ShowSizesCommand = new RelayCommand(ShowSizeData);
            ShowToppingsCommand = new RelayCommand(ShowToppingData);
        }

        private void Load()
        {

            Data = new ObservableCollection<object>();

            crustService = new CrustService();
            drinkService = new DrinkService();
            sideService = new SideService();
            sizeService = new SizeService();
            toppingService = new ToppingService();

            Crusts = new ObservableCollection<Crust>(crustService.GetAll());

            Drinks = new ObservableCollection<Drink>(drinkService.GetAll());

            Sizes = new ObservableCollection<BusinessObjects.Size>(sizeService.GetAll());
            Sides = new ObservableCollection<Side>(sideService.GetAll());
            Toppings = new ObservableCollection<Topping>(toppingService.GetAll());

            foreach (var crust in crustService.GetAll())
            {
                if (crust != null) Data.Add(crust);
            }

        }

        private void ShowCrustData(object c)
        {
            LoadData("crust");
        }
        private void ShowDrinkData(object c)
        {
            LoadData("drink");
        }
        private void ShowSizeData(object c)
        {
            LoadData("size");
        }
        private void ShowSideData(object c)
        {
            LoadData("side");
        }

        private void ShowToppingData(object c)
        {
            LoadData("topping");
        }

        private void LoadData(string dataType)
        {
            Data.Clear();
            IEnumerable<object> newData = Enumerable.Empty<object>();

            switch (dataType)
            {
                case "crust":
                    newData = crustService.GetAll();
                    break;
                case "drink":
                    newData = drinkService.GetAll();
                    break;
                case "side":
                    newData = sideService.GetAll();
                    break;
                case "size":
                    newData = sizeService.GetAll();
                    break;
                case "topping":
                    newData = toppingService.GetAll();
                    break;
            }


            foreach (var item in newData)
            {
                Data.Add(item);
            }

            OnPropertyChanged(nameof(Data));
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateTextBoxValues()
        {
            if (SelectedItem is Crust crust)
            {
                ProductName = crust.Type;
                ProductPrice = "";
            }
            else if (SelectedItem is Drink drink)
            {
                ProductName = drink.Name;
                ProductPrice = drink.Price.ToString();
            }
            else if (SelectedItem is Side side)
            {
                ProductName = side.Name;
                ProductPrice = side.Price.ToString();
            }
            else if (SelectedItem is BusinessObjects.Size size)
            {
                ProductName = size.Description;
                ProductPrice = size.Price.ToString();
            }
            else if (SelectedItem is Topping topping)
            {
                ProductName = topping.Name;
                ProductPrice = topping.Price.ToString();
            }
        }
    }
}
