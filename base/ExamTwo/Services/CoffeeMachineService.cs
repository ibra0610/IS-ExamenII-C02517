using ExamTwo.Repositories;
using ExamTwo.DTO;

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

        public string BuyCoffee(OrderRequest request)
        {
            if (request.Order == null || request.Order.Count == 0)
                throw new ArgumentException("Orden vacía.");

            if (request.Payment.TotalAmount <= 0)
                throw new ArgumentException("Dinero insuficiente.");

        }
    }

}
