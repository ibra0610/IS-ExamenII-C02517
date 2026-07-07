using ExamTwo.Controllers;

namespace ExamTwo.Services
{
    public class CoffeeMachineService : Service
    {

        private readonly Database _db;

        public CoffeeMachineService(Database db)
        {
            _db = db;
        }

        public Dictionary<string, int> GetCoffeePrices()
        {
            return _db.keyValues;
        }

        public Dictionary<string, int> GetCoffeePricesInCents()
        {
            return _db.keyValues2;
        }

        public Dictionary<string, int> GetQuantity()
        {
            return _db.keyValues3
        }
    }

}
