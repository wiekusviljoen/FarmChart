using Farm.Data;
using Microsoft.AspNetCore.Mvc;

namespace Farm.Controllers.Charts
{
    public class CattleChartController : Controller
    {
        private readonly FarmContext _context;

        public CattleChartController(FarmContext context)
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

        public List<object> GetCattle()
        {
            List<object> data = new List<object>();

            List<string> labels = _context.Cattle.Select(p => p.Camp).ToList();

            data.Add(labels);

            List<int> SalesNumber = _context.Cattle.Select(p => p.Total).ToList();

            data.Add(SalesNumber);

            return data;
        }





    }
}
