using BusinessObjects;

namespace DataAccessLayer
{
    public class ToppingDAO
    {
        private PizzaOrderSystemContext _dbContext;
        public ToppingDAO()
        {
            _dbContext = new PizzaOrderSystemContext();
        }
        public IEnumerable<Topping> GetAll()
        {
            return _dbContext.Toppings.ToList();
        }
    }
}
