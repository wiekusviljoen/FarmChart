using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Farm.Data;
using Farm.Models;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace Farm.Controllers
{
    public class CattleController : Controller
    {
        private readonly FarmContext _context;

        public CattleController(FarmContext context)
        {
            _context = context;
        }

        // GET: Cattle
        public async Task<IActionResult> Index()
        {
              return _context.Cattle != null ? 
                          View(await _context.Cattle.ToListAsync()) :
                          Problem("Entity set 'FarmContext.Cattle'  is null.");
        }

        //GET: ShowSearchFormCamp
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        //Post: ShowSearchResults
        public async Task<IActionResult> ShowSearchResultsCamp(String SearchPhrase)
        {

            return View("Index", await _context.Cattle.Where(j => j.Camp.Contains(SearchPhrase)).ToListAsync());

           
        }

        //GET: ShowSearchFormBreed
        public async Task<IActionResult> ShowSearchFormBreed()
        {
            return View();
        }

        public async Task<IActionResult> ShowSearchResultsBreed(String SearchPhrase)
        {
            return View("Index", await _context.Cattle.Where(j => j.Breed.Contains(SearchPhrase)).ToListAsync());

        }


        ////GET: ShowSearchFormYear
        //public async Task<IActionResult> ShowSearchFormYear()
        //{
        //    return View();
        //}

        //public async Task<IActionResult> ShowSearchResultsYear(DateTime SearchPhrase)
        //{
        //    return View("Index", await _context.Cattle.Where(i => i.DateAndTime.Year(SearchPhrase)).ToListAsync());

        //}

        // GET: Cattle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cattle == null)
            {
                return NotFound();
            }

            var cattle = await _context.Cattle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cattle == null)
            {
                return NotFound();
            }

            return View(cattle);
        }

        // GET: Cattle/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cattle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateAndTime,Camp,Breed,Bulls,Cows,BullCalf,CowCalf,NewCalf,Missing,Dead,Branded,Dipped,Injected,Feed,FeedPrice,FeedQuantity,Notes")] Cattle cattle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cattle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cattle);
        }

        // GET: Cattle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cattle == null)
            {
                return NotFound();
            }

            var cattle = await _context.Cattle.FindAsync(id);
            if (cattle == null)
            {
                return NotFound();
            }
            return View(cattle);
        }

        // POST: Cattle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateAndTime,Camp,Breed,Bulls,Cows,BullCalf,CowCalf,NewCalf,Missing,Dead,Branded,Dipped,Injected,Feed,FeedPrice,FeedQuantity,Notes")] Cattle cattle)
        {
            if (id != cattle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cattle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CattleExists(cattle.Id))
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
            return View(cattle);
        }

        // GET: Cattle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cattle == null)
            {
                return NotFound();
            }

            var cattle = await _context.Cattle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cattle == null)
            {
                return NotFound();
            }

            return View(cattle);
        }

        // POST: Cattle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cattle == null)
            {
                return Problem("Entity set 'FarmContext.Cattle'  is null.");
            }
            var cattle = await _context.Cattle.FindAsync(id);
            if (cattle != null)
            {
                _context.Cattle.Remove(cattle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CattleExists(int id)
        {
          return (_context.Cattle?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
