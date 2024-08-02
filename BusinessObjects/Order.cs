using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Order
{
    public int Id { get; set; }

    public DateOnly OrderDate { get; set; }

    public TimeOnly OrderTime { get; set; }

    public int? CustomerId { get; set; }

    public string ShippingAddress { get; set; } = null!;

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<DrinkOrder> DrinkOrders { get; set; } = new List<DrinkOrder>();

    public virtual ICollection<PizzaOrder> PizzaOrders { get; set; } = new List<PizzaOrder>();

    public virtual ICollection<SideOrder> SideOrders { get; set; } = new List<SideOrder>();
}
