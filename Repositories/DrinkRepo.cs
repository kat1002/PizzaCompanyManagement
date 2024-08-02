using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class DrinkRepo
    {
        private DrinkDAO drinkDAO;
        public DrinkRepo()
        {
            drinkDAO = new DrinkDAO();
        }
        public IEnumerable<Drink> GetAll()
        {
            return drinkDAO.GetAll();
        }
    }
}
