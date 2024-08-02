using BusinessObjects;
using Repositories;

namespace Services
{
    public class SideService 
    {
        private SideRepo sideRepo;

        public SideService()
        {
            sideRepo = new SideRepo();
        }
        public IEnumerable<Side> GetAll()
        {
            return sideRepo.GetAll();
        }
    }
}
