using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Farm.Data;
using Farm.Models;
using System.Diagnostics;
using Farm.Interfaces;

namespace Farm.Controllers
{
    public class RainController : Controller
    {
        private readonly IRainRepository _rainRepository;

        public RainController(IRainRepository rainRepository)
        {
            _rainRepository = rainRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var rain = _rainRepository.GetAll();
            return View(rain);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(RainModel rainModel)
        {
            _rainRepository.Insert(rainModel);
            _rainRepository.Save();
            return RedirectToAction("Index");
        }




        [HttpGet]
        public IActionResult Delete(int id)
        {
            var rain = _rainRepository.GetById(id);
            return View(rain);
        }


        [HttpPost]
        public IActionResult Delete(RainModel rainModel)
        {
            _rainRepository.Delete(rainModel);
            _rainRepository.Save();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var rain = _rainRepository.GetById(id);
            return View(rain);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var rain = _rainRepository.GetById(id);
            return View(rain);
        }

        [HttpPost]
        public IActionResult Edit(RainModel rainModel)
        {
            _rainRepository.Update(rainModel);
            _rainRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public async Task<IActionResult> ShowSearchForm()
        //{
        //    return View();
        //}

        ////Post: ShowSearchResults
        //public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        //{
        //    return View("Index", await _context.RainModel.Where(j => j.Camp.Contains(SearchPhrase)).ToListAsync());

        //}
    }
}
