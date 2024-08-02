using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class OrderDAO 
    {
        private PizzaOrderSystemContext _dbContext;
        public OrderDAO()
        {
            _dbContext = new PizzaOrderSystemContext();
        }
        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders
                .Include(o => o.Customer)
                .Include(o => o.DrinkOrders).ThenInclude(dor => dor.Drink)
                .Include(o => o.PizzaOrders).ThenInclude(po => po.Pizza)
                    .ThenInclude(p => p.Crust)
                .Include(o => o.PizzaOrders).ThenInclude(po => po.Pizza)
                    .ThenInclude(p => p.Size)
                .Include(o => o.PizzaOrders).ThenInclude(po => po.Pizza)
                    .ThenInclude(p => p.Toppings)
                .Include(o => o.SideOrders).ThenInclude(so => so.Side)
                .ToList();
        }

        public IEnumerable<Order> GetCustomerOrders(int uid)
        {
            return _dbContext.Orders.Where(o => o.Customer.Id == uid)
                .Include(o => o.Customer)
                .Include(o => o.DrinkOrders).ThenInclude(dor => dor.Drink)
                .Include(o => o.PizzaOrders).ThenInclude(po => po.Pizza)
                    .ThenInclude(p => p.Crust)
                .Include(o => o.PizzaOrders).ThenInclude(po => po.Pizza)
                    .ThenInclude(p => p.Size)
                .Include(o => o.PizzaOrders).ThenInclude(po => po.Pizza)
                    .ThenInclude(p => p.Toppings)
                .Include(o => o.SideOrders).ThenInclude(so => so.Side);
        }
        public void AddOrder(Order newOrder)
        {
            using (var context = new PizzaOrderSystemContext())
            {
                context.Attach(newOrder.Customer);

                foreach (var item in newOrder.PizzaOrders)
                {
                    // Ensure the associated Crust and Size are attached to the context
                    context.Attach(item.Pizza.Crust);
                    context.Attach(item.Pizza.Size);

                    // Ensure each Topping is attached or added to the context
                    foreach (var topping in item.Pizza.Toppings)
                    {
                        context.Attach(topping); // Attach existing topping
                    }

                    context.Pizzas.Add(item.Pizza);
                }
                context.SaveChanges();

                foreach (var item in newOrder.DrinkOrders)
                {
                    context.Attach(item);
                }

                foreach (var item in newOrder.SideOrders)
                {
                    context.Attach(item);
                }

                // Add to Database
                context.Orders.Add(newOrder);
                context.SaveChanges();
            }
        }
        public IEnumerable<Order> GetOrderByDateRange(DateTime beginDate, DateTime endDate)
        {
            var begin = DateOnly.FromDateTime(beginDate);
            var end = DateOnly.FromDateTime(endDate);
            return GetAll().Where(o => o.OrderDate >= begin && o.OrderDate <= end).ToList();
        }
    }
}
