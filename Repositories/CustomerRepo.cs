using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class CustomerRepo
    {
        private CustomerDAO customerDAO;

        public CustomerRepo()
        {
            customerDAO = new CustomerDAO();
        }

        public Customer AddCustomer(Customer customer)
        {
            return customerDAO.AddCustomer(customer);
        }

        public bool CheckEmailDuplicated(string email)
        {
            return customerDAO.GetAll().FirstOrDefault(c => c.Email.Equals(email)) != null;
        }

        public bool CheckPhoneDuplicated(string phone)
        {
            return customerDAO.GetAll().FirstOrDefault(c => c.Phone.Equals(phone)) != null;
        }

        public void DisableCustomer(Customer customer)
        {
            customerDAO.DisableCustomer(customer);
        }

        public void EnableCustomer(Customer customer)
        {
            customerDAO.EnableCustomer(customer);
        }
        public void DisableAdminCustomer(Customer customer)
        {
            customerDAO.DisableAdminCustomer(customer);
        }

        public void EnableAdminCustomer(Customer customer)
        {
            customerDAO.EnableAdminCustomer(customer);
        }

        public IEnumerable<Customer> GetAll()
        {
            return customerDAO.GetAll();
        }

        public Customer GetCustomer(int id)
        {
            return customerDAO.GetCustomer(id);
        }

        public Customer GetCustomer(string email, string password)
        {
            return customerDAO.GetCustomer(email, password);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            return customerDAO.UpdateCustomer(customer);
        }

        public void DeleteCustomer(int id)
        {
            customerDAO.DeleteCustomer(id);
        }
    }
}
