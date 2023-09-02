using Farm.Data;
using Microsoft.AspNetCore.Mvc;

namespace Farm.Controllers.Charts
{
    public class CostController : Controller
    {
        private readonly FarmContext _context;

        public CostController(FarmContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }


        public List<object> GetCattleCosts()
        {
            List<object> data = new List<object>();

            List<string> labels = _context.Cattle.Select(p => p.Camp).ToList();

            data.Add(labels);

            List<float> SalesNumber = _context.Cattle.Select(p => p.FeedPricePerMonth).ToList();

            data.Add(SalesNumber);

            return data;
        }
    }
}
