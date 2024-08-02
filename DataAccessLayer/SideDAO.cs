using BusinessObjects;

namespace DataAccessLayer
{
    public class SideDAO 
    {
        private PizzaOrderSystemContext _dbContext;
        public SideDAO()
        {
            _dbContext = new PizzaOrderSystemContext();
        }
        public IEnumerable<Side> GetAll()
        {
            return _dbContext.Sides.ToList();
        }
    }
}
