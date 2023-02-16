using Farm.Data;
using Microsoft.AspNetCore.Mvc;

namespace Farm.Controllers
{
    public class RainChartController : Controller
    {
        private readonly FarmContext _context;

        public RainChartController(FarmContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowRain()
        {
            return View();
        }

        [HttpPost]

        public List<object> GetRain()
        {
            List<object> data = new List<object>();

            List<string> labels = _context.RainModel.Select(p => p.Camp).ToList();

            data.Add(labels);


            List<double> RainAmount = _context.RainModel.Select(p => p.Amount).ToList();

            data.Add(RainAmount);

           

            return data;
        }
    }
}
