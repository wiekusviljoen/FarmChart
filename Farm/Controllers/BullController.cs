using Farm.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Farm.Controllers
{
    public class BullController : Controller
    {

        private readonly FarmContext _context;

        public BullController(FarmContext context)
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

            List<int> SalesNumber = _context.Cattle.Select(p => p.Bulls).ToList();

            data.Add(SalesNumber);

            return data;
        }
    }
}
