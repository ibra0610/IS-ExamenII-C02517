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

            var costoTotal = request.Order.Sum(o => _db.keyValues2.First(c => c.Key == o.Key).Value * o.Value);

            if (request.Payment.TotalAmount < costoTotal)
                throw new ArgumentException("Dinero insuficiente.");

            foreach (var cafe in request.Order)
            {
                var selected = _db.keyValues.First(c => c.Key == cafe.Key).Key;
                if (cafe.Value > _db.keyValues[selected])
                {
                    throw new ArgumentException($"No hay suficientes {selected} en la máquina.");
                }

                UpdateInventory(selected, cafe)
            }
        }

        public void UpdateInventory(var selected, var cafe)
        {
            _db.keyValues[selected] -= cafe.Value;
        }

        
    }

}
