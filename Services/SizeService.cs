using BusinessObjects;
using Repositories;

namespace Services
{
    public class SizeService 
    {
        private readonly SizeRepo sizeRepo;
        public SizeService()
        {
            sizeRepo = new SizeRepo();
        }
        public IEnumerable<Size> GetAll()
        {
            return sizeRepo.GetAll();
        }
    }
}
