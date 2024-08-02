using BusinessObjects;
using Repositories;
namespace Services
{
    public class ToppingService 
    {
        private ToppingRepo toppingRepo;

        public ToppingService()
        {
            toppingRepo = new ToppingRepo();
        }
        public IEnumerable<Topping> GetAll()
        {
            return toppingRepo.GetAll();
        }
    }
}
