using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class ToppingRepo
    {
        private ToppingDAO toppingDAO;
        public ToppingRepo()
        {
            toppingDAO = new ToppingDAO();
        }
        public IEnumerable<Topping> GetAll()
        {
            return toppingDAO.GetAll();
        }
    }
}
