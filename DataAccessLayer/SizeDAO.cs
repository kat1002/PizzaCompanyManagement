using BusinessObjects;

namespace DataAccessLayer
{
    public class SizeDAO 
    {
        private PizzaOrderSystemContext _dbContext;
        public SizeDAO()
        {
            _dbContext = new PizzaOrderSystemContext();
        }
        public IEnumerable<Size> GetAll()
        {
            return _dbContext.Sizes.ToList();
        }
    }
}
