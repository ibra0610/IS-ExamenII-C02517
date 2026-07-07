

namespace ExamTwo.Services
{
    public class CoffeeMachineService : Service
    {

        private readonly Database _db;

        public CoffeeMachineService(Database db)
        {
            _db = db;
        }
    }

    public class OrderRequest
    {
        public Dictionary<string, int> Order { get; set; }
        public Payment Payment { get; set; }
    }

    public class Payment
    {
        public int TotalAmount { get; set; }
        public List<int> Coins { get; set; }
        public List<int> Bills { get; set; }
    }
}
