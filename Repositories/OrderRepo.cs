using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class OrderRepo
    {
        private OrderDAO orderDAO;
        public OrderRepo()
        {
            orderDAO = new OrderDAO();
        }

        public void AddOrder(Order order)
        {
            orderDAO.AddOrder(order);
        }

        public IEnumerable<Order> GetAll()
        {
            return orderDAO.GetAll();
        }

        public IEnumerable<Order> GetCustomerOrders(int uid)
        {
            return orderDAO.GetCustomerOrders(uid);
        }
        public IEnumerable<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            return orderDAO.GetOrderByDateRange(startDate, endDate);
        }
    }
}
