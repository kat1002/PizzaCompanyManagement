using BusinessObjects;

namespace DataAccessLayer
{
    public class CrustDAO 
    {
        private PizzaOrderSystemContext _dbContext;
        public CrustDAO()
        {
            _dbContext = new PizzaOrderSystemContext();
        }
        public IEnumerable<Crust> GetAll()
        {
            return _dbContext.Crusts.ToList();
        }
    }
}
