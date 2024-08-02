namespace BusinessObjects;

public partial class Side
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<SideOrder> SideOrders { get; set; } = new List<SideOrder>();

    public override string ToString()
    {
        return $"{Name} (${Price})";
    }
}
