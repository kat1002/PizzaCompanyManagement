namespace BusinessObjects;

public partial class Drink
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<DrinkOrder> DrinkOrders { get; set; } = new List<DrinkOrder>();

    public override string ToString()
    {
        return $"{Name} (${Price})";
    }
}
