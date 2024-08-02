using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class CrustRepo
    {
        private CrustDAO crustDAO;
        public CrustRepo()
        {
            crustDAO = new CrustDAO();
        }
        public IEnumerable<Crust> GetAll()
        {
            return crustDAO.GetAll();
        }
    }
}
