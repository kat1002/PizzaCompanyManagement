using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects;

public partial class SideOrder : INotifyPropertyChanged
{
    public int SideId { get; set; }

    public int OrderId { get; set; }

    private int _quantity;
    public int Quantity
    {
        get { return _quantity; }
        set
        {
            if (_quantity != value)
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
                UpdatePrice();
            }
        }
    }

    private decimal _price;
    [NotMapped]
    public decimal Price
    {
        get
        {
            _price = Quantity * Side.Price;
            return _price;
        }
        set
        {
            if (_price != value)
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public virtual Order Order { get; set; } = null!;

    public virtual Side Side { get; set; } = null!;
    private void UpdatePrice()
    {
        Price = Side.Price * Quantity;
    }
}
