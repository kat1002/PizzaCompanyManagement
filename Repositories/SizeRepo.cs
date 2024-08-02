using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class SizeRepo 
    {
        private SizeDAO sizeDAO;
        public SizeRepo()
        {
            sizeDAO = new SizeDAO();
        }
        public IEnumerable<Size> GetAll()
        {
            return sizeDAO.GetAll();
        }
    }
}
