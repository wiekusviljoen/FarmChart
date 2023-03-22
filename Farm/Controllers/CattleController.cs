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
using System.Diagnostics;
using Farm.Interfaces;

namespace Farm.Controllers
{
    public class CattleController : Controller
    {
        private readonly ICattleRepository _cattleRepository;

        public CattleController(ICattleRepository cattleRepository)
        {
            _cattleRepository = cattleRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cattle = _cattleRepository.GetAll();
            return View(cattle);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Cattle cattle)
        {
            _cattleRepository.Insert(cattle);
            _cattleRepository.Save();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var cattle = _cattleRepository.GetById(id);
            return View(cattle);
        }


        [HttpPost]
        public IActionResult Delete(Cattle cattle)
        {
            _cattleRepository.Delete(cattle);
            _cattleRepository.Save();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var cattle = _cattleRepository.GetById(id);
            return View(cattle);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cattle = _cattleRepository.GetById(id);
            return View(cattle);
        }

        [HttpPost]
        public IActionResult Edit(Cattle cattle)
        {
            _cattleRepository.Update(cattle);
            _cattleRepository.Save();
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
    }
}
