namespace BusinessObjects;

public partial class Pizza
{
    public int Id { get; set; }

    public int? CrustId { get; set; }

    public int? SizeId { get; set; }

    public decimal Price { get; set; }

    public virtual Crust? Crust { get; set; }

    public virtual ICollection<PizzaOrder> PizzaOrders { get; set; } = new List<PizzaOrder>();

    public virtual Size? Size { get; set; }

    public virtual ICollection<Topping> Toppings { get; set; } = new List<Topping>();

    public override bool Equals(object? obj)
    {
        var pizza = obj as Pizza;
        if (pizza.SizeId == SizeId && pizza.CrustId == CrustId && CheckEqualToppings(pizza))
        {
            return true;
        }
        return false;
    }

    private bool CheckEqualToppings(Pizza p)
    {
        foreach (var item in p.Toppings)
        {
            var check = Toppings.FirstOrDefault(t => t.Id == item.Id);
            if (check == null) return false;
        }
        return true;
    }
}
