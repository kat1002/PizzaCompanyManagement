using BusinessObjects;
using Repositories;
namespace Services
{
    public class OrderService 
    {
        private OrderRepo orderRepo;
        public OrderService()
        {
            orderRepo = new OrderRepo();
        }

        public void AddOrder(Order order)
        {
            orderRepo.AddOrder(order);
        }

        public IEnumerable<Order> GetAll()
        {
            return orderRepo.GetAll();
        }

        public IEnumerable<Order> GetCustomerOrders(int uid)
        {
            return orderRepo.GetCustomerOrders(uid);
        }
        public IEnumerable<Order> GetOrdersByDateRange(DateTime beginDate, DateTime endDate)
        {
            return orderRepo.GetOrdersByDateRange(beginDate, endDate);
        }
    }
}
