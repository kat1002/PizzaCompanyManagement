namespace BusinessObjects;

public partial class Topping
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>();

    public override string ToString()
    {
        return $"{Name} (${Price})";
    }
}
