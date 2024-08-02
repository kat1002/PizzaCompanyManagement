using BusinessObjects;
using Repositories;

namespace Services
{
    public class CrustService 
    {
        private CrustRepo crustRepo;

        public CrustService()
        {
            crustRepo = new CrustRepo();
        }
        public IEnumerable<Crust> GetAll()
        {
            return crustRepo.GetAll();
        }
    }
}
