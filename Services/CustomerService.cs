using BusinessObjects;
using Repositories;

namespace Services
{
    public class CustomerService 
    {
        private CustomerRepo customerRepo;

        public CustomerService()
        {
            customerRepo = new CustomerRepo();
        }

        public Customer AddCustomer(Customer customer)
        {
            return customerRepo.AddCustomer(customer);
        }

        public bool CheckEmailDuplicated(string email)
        {
            return customerRepo.CheckEmailDuplicated(email);
        }

        public bool CheckPhoneDuplicated(string phone)
        {
            return customerRepo.CheckPhoneDuplicated(phone);
        }

        public void DisableCustomer(Customer customer)
        {
            customerRepo.DisableCustomer(customer);
        }
        public void EnableCustomer(Customer customer)
        {
            customerRepo.EnableCustomer(customer);
        }

        public void DisableAdminCustomer(Customer customer)
        {
            customerRepo.DisableAdminCustomer(customer);
        }
        public void EnableAdminCustomer(Customer customer)
        {
            customerRepo.EnableAdminCustomer(customer);
        }

        public IEnumerable<Customer> GetAll()
        {
            return customerRepo.GetAll();
        }

        public Customer GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(string email, string password)
        {
            return customerRepo.GetCustomer(email, password);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            return customerRepo.UpdateCustomer(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            customerRepo.DeleteCustomer(customer.Id);
        }
    }
}
