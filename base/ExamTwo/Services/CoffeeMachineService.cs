using ExamTwo.Repositories;
using ExamTwo.DTO;

namespace ExamTwo.Services
{
    public class CoffeeMachineService
    {

        private readonly Database _db;

        public CoffeeMachineService(Database db)
        {
            _db = db;
        }

        public Dictionary<string, int> GetCoffeeInventory()
        {
            return _db.keyValues;
        }

        public Dictionary<string, int> GetCoffeePrices()
        {
            return _db.keyValues2;
        }

        public Dictionary<int, int> GetCoinsQuantity()
        {
            return _db.keyValues3;
        }

        public string BuyCoffee(OrderRequest request)
        {
            
            if (request.Order == null || request.Order.Count == 0)
                throw new ArgumentException("Orden vacía.");

            var costoTotal = request.Order.Sum(o => _db.keyValues2.First(c => c.Key == o.Key).Value * o.Value);

            if (request.Payment.TotalAmount < costoTotal)
                throw new ArgumentException("Dinero insuficiente.");

            
            CheckAndUpdateItems(request);

            var result = GetChange(request, costoTotal);

            return result;
        }

        public void CheckAndUpdateItems(OrderRequest request)
        {
            foreach (var cafe in request.Order)
            {
                var selected = _db.keyValues.First(c => c.Key == cafe.Key).Key;
                if (cafe.Value > _db.keyValues[selected])
                {
                    throw new ArgumentException($"No hay suficientes {selected} en la máquina.");
                }
                int cafeValue = cafe.Value;

                UpdateInventory(selected, cafeValue);
            }
        }

        public string GetChange(OrderRequest request, int costoTotal)
        {
            var change = request.Payment.TotalAmount - costoTotal;
            String result = $"Su vuelto es de: {change} colones. Desglose:";

            foreach (var coin in _db.keyValues3.Keys.OrderByDescending(c => c))
            {
                var count = Math.Min(change / coin, _db.keyValues3[coin]);
                if (count > 0)
                {
                    result +=  $" {count} moneda de {coin},  ";              
                    change -= coin * count;
                }
            }

            if (change > 0)
            {
                throw new ArgumentException("No hay suficiente cambio en la máquina.");
            }

            return result;
        }

        public void UpdateInventory(string selected, int cafeValue)
        {
            _db.keyValues[selected] -= cafeValue;
        }
  
    }

}
