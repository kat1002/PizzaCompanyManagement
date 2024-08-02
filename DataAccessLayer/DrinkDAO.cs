using BusinessObjects;

namespace DataAccessLayer
{
    public class DrinkDAO
    {
        private PizzaOrderSystemContext _dbContext;
        public DrinkDAO()
        {
            _dbContext = new PizzaOrderSystemContext();
        }
        public IEnumerable<Drink> GetAll()
        {
            return _dbContext.Drinks.ToList();
        }
    }
}
