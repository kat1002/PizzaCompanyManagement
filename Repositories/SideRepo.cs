using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class SideRepo 
    {
        private SideDAO sideDAO;
        public SideRepo()
        {
            sideDAO = new SideDAO();
        }

        public IEnumerable<Side> GetAll()
        {
            return sideDAO.GetAll();
        }
    }
}
