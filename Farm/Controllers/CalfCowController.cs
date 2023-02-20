using Farm.Data;
using Microsoft.AspNetCore.Mvc;

namespace Farm.Controllers
{
    public class CalfCowController : Controller
    {
        private readonly FarmContext _context;

        public CalfCowController(FarmContext context)
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

        public List<object> GetCattleCalfCow()
        {
            List<object> data = new List<object>();

            List<string> labels = _context.Cattle.Select(p => p.Camp).ToList();
            data.Add(labels);

            List<int> SalesNumber = _context.Cattle.Select(p => p.CowCalf).ToList();

            data.Add(SalesNumber);

            return data;
        }
    }
}
