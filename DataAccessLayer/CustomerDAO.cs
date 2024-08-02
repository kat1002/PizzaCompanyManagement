using BusinessObjects;
using System.Linq;

namespace DataAccessLayer
{
    public class CustomerDAO 
    {
        private PizzaOrderSystemContext _dbContext;
        public CustomerDAO()
        {
            _dbContext = new PizzaOrderSystemContext();
        }

        public Customer AddCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }

        public bool CheckEMailDuplicated(string email)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.Email == email);

            return customer != null;
        }

        public bool CheckPhoneDuplicated(string phone)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.Phone == phone);

            return customer != null;
        }

        public void DisableCustomer(Customer customer)
        {
            var exitCustomer = _dbContext.Customers.FirstOrDefault(c => c.Id == customer.Id);

            if (exitCustomer == null) throw new Exception("User not found");

            exitCustomer.State = false;

            _dbContext.SaveChanges();
        }

        public void EnableCustomer(Customer customer)
        {
            var exitCustomer = _dbContext.Customers.FirstOrDefault(c => c.Id == customer.Id);

            if (exitCustomer == null) throw new Exception("User not found");

            exitCustomer.State = true;

            _dbContext.SaveChanges();
        }

        public void DisableAdminCustomer(Customer customer)
        {
            var exitCustomer = _dbContext.Customers.FirstOrDefault(c => c.Id == customer.Id);

            if (exitCustomer == null) throw new Exception("User not found");

            exitCustomer.IsAdmin = false;

            _dbContext.SaveChanges();
        }

        public void EnableAdminCustomer(Customer customer)
        {
            var exitCustomer = _dbContext.Customers.FirstOrDefault(c => c.Id == customer.Id);

            if (exitCustomer == null) throw new Exception("User not found");

            exitCustomer.IsAdmin = true;

            _dbContext.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _dbContext.Customers.ToList();
        }

        public Customer GetCustomer(int id)
        {
            return _dbContext.Customers.FirstOrDefault(c => c.Id == id);
        }

        public void DeleteCustomer(int id)
        {
            // Remove the customer
            var customer = _dbContext.Customers.Find(id);
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
            }

            // Save changes to the database
            _dbContext.SaveChanges();
        }


        public Customer GetCustomer(string email, string password)
        {
            return _dbContext.Customers.FirstOrDefault(c => c.Email == email && c.Password == password);
        }


        public Customer UpdateCustomer(Customer customer)
        {
            var exitCustomer = _dbContext.Customers.FirstOrDefault(c => c.Id == customer.Id);

            if (exitCustomer == null)
            {
                throw new Exception("User not found");
            }
            exitCustomer.Name = customer.Name;
            exitCustomer.Email = customer.Email;
            exitCustomer.Password = customer.Password;
            exitCustomer.Address = customer.Address;
            exitCustomer.Phone = customer.Phone;

            _dbContext.SaveChanges();

            return exitCustomer;
        }
    }
}
