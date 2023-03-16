using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Farm.Data;
using Farm.Models;

namespace Farm.Controllers
{
    public class RainController : Controller
    {
        private readonly FarmContext _context;

        public RainController(FarmContext context)
        {
            _context = context;
        }

        // GET: Rain
        public async Task<IActionResult> Index()
        {
              return _context.RainModel != null ? 
                          View(await _context.RainModel.ToListAsync()) :
                          Problem("Entity set 'FarmContext.RainModel'  is null.");
        }

        //GET: ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        //Post: ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("Index", await _context.RainModel.Where(j => j.Camp.Contains(SearchPhrase)).ToListAsync());
            
        }



        // GET: Rain/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RainModel == null)
            {
                return NotFound();
            }

            var rainModel = await _context.RainModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rainModel == null)
            {
                return NotFound();
            }

            return View(rainModel);
        }

        // GET: Rain/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rain/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Camp,Amount")] RainModel rainModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rainModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rainModel);
        }

        // GET: Rain/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RainModel == null)
            {
                return NotFound();
            }

            var rainModel = await _context.RainModel.FindAsync(id);
            if (rainModel == null)
            {
                return NotFound();
            }
            return View(rainModel);
        }

        // POST: Rain/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Camp,Amount")] RainModel rainModel)
        {
            if (id != rainModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rainModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RainModelExists(rainModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rainModel);
        }

        // GET: Rain/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RainModel == null)
            {
                return NotFound();
            }

            var rainModel = await _context.RainModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rainModel == null)
            {
                return NotFound();
            }

            return View(rainModel);
        }

        // POST: Rain/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RainModel == null)
            {
                return Problem("Entity set 'FarmContext.RainModel'  is null.");
            }
            var rainModel = await _context.RainModel.FindAsync(id);
            if (rainModel != null)
            {
                _context.RainModel.Remove(rainModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RainModelExists(int id)
        {
          return (_context.RainModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
