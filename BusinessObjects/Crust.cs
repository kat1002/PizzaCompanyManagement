namespace BusinessObjects;

public partial class Crust
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>();

    public override string ToString()
    {
        return Type;
    }
}
