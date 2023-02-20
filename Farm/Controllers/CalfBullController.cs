using Farm.Data;
using Microsoft.AspNetCore.Mvc;

namespace Farm.Controllers
{
    public class CalfBullController : Controller
    {
        private readonly FarmContext _context;

        public CalfBullController(FarmContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowCattle()
        {
            return View();
        }

        [HttpPost]

        public List<object> GetCattleCalfBull()
        {
            List<object> data = new List<object>();

            List<string> labels = _context.Cattle.Select(p => p.Camp).ToList();
            data.Add(labels);

            List<int> SalesNumber = _context.Cattle.Select(p => p.BullCalf).ToList();

            data.Add(SalesNumber);

            return data;
        }
    }
}
