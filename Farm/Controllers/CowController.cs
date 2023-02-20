using Farm.Data;
using Microsoft.AspNetCore.Mvc;

namespace Farm.Controllers
{
    public class CowController : Controller
    {
        private readonly FarmContext _context;

        public CowController(FarmContext context)
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

        public List<object> GetCattleCow()
        {
            List<object> data = new List<object>();

            List<string> labels = _context.Cattle.Select(p => p.Camp).ToList();
            data.Add(labels);

            List<int> SalesNumber = _context.Cattle.Select(p => p.Cows).ToList();

            data.Add(SalesNumber);

            return data;
        }
        

    }
}
