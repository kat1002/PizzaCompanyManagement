namespace BusinessObjects;

public partial class Size
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>();

    public override string ToString()
    {
        return Description;
    }
}
