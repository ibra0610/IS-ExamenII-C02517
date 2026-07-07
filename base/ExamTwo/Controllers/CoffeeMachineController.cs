using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExamTwo.Services;
using ExamTwo.DTO;

namespace ExamTwo.Controllers
{
    public class CoffeeMachineController : Controller
    {

        private CoffeeMachineService _coffeeMachineService;


        public CoffeeMachineController(CoffeeMachineService coffeeMachineService)
        {
            _coffeeMachineService = coffeeMachineService;
        }

        [HttpGet("getCoffees")]
        public ActionResult<Dictionary<string, int>> GetCoffeePrices()
        {
            return Ok(_coffeeMachineService.GetCoffeePrices());
        }

        [HttpGet("getCoffeePricesInCents")]
        public ActionResult<Dictionary<string, int>> GetCoffeePricesInCents()
        {
            return Ok(_coffeeMachineService.GetCoffeePricesInCents());
        }

        [HttpGet("getQuantity")]
        public ActionResult<Dictionary<string, int>> GetQuantity()
        {
            return Ok(_coffeeMachineService.GetQuantity());
        }

        [HttpPost("buyCoffee")]
        public ActionResult<string> BuyCoffee([FromBody] OrderRequest request)
        {
            try
            {
                return Ok(_coffeeMachineService.BuyCoffee(request));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
