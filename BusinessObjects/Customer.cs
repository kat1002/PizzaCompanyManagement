using System.ComponentModel;

namespace BusinessObjects;

public partial class Customer : INotifyPropertyChanged
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Password { get; set; } = null!;

    private bool _state;
    private bool _isAdmin;

    public bool State
    {
        get { return _state; }
        set
        {
            if (_state != value)
            {
                _state = value;
                OnPropertyChanged(nameof(State));
            }
        }
    }

    public bool IsAdmin
    {
        get { return _isAdmin; }
        set
        {
            if (_isAdmin != value)
            {
                _isAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
            }
        }
    }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
