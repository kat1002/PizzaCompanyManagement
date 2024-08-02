using BusinessObjects;
using Repositories;

namespace Services
{
    public class DrinkService 
    {
        private DrinkRepo drinkRepo;

        public DrinkService()
        {
            drinkRepo = new DrinkRepo();
        }
        public IEnumerable<Drink> GetAll()
        {
            return drinkRepo.GetAll();
        }
    }
}
