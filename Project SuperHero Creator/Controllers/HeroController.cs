using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_SuperHero_Creator.Data;
using Project_SuperHero_Creator.Models;

namespace Project_SuperHero_Creator.Controllers
{
    public class HeroController : Controller
    {
        ApplicationDbContext _context;

        public HeroController(ApplicationDbContext context)
        {
            context = _context;
        }
        // GET: Hero
        public ActionResult Index()
        {
           
            return View( );
        }

        // GET: Hero/Details/
        public ActionResult Details(int id)
        {
            _context.Heroes.Where(h => h.Id == id);
            return View(id);
        }

        // GET: Hero/Create
        [HttpGet]
        public ActionResult Create()
        {
            SuperHeroes heroes = new SuperHeroes();
            return View(heroes);
        }

        // POST: Hero/Create
        [HttpPost]
        public ActionResult Create(SuperHeroes heroes)
        {
            var newhero = heroes;
            _context.Heroes.Add(newhero);
            _context.SaveChanges();
            return RedirectToAction("Index");   
        } 
         
        // GET: Hero/Edit/
        [HttpGet]
        public ActionResult Edit(int id)
        { 
            _context.Heroes.Where(h => h.Id == id);
            return View(id);
        }

        // POST: Hero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SuperHeroes heroes)
        {
            var EditHero = heroes;
            if (heroes.Id == id)
            { 
                _context.Heroes.Add(EditHero);
                _context.SaveChanges();

            }
           
            return RedirectToAction(nameof(Index));
            
        }   

        // GET: Hero/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _context.Heroes.Where(h => h.Id == id);
            return View(id);
        }

        // POST: Hero/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SuperHeroes heroes)
        {
            var removeheore = heroes;
            if (heroes.Id == id)
            {
              _context.Heroes.Where(h => h.Id == removeheore.Id && h.HeroName == removeheore.HeroName && h.PrimaryAbility == removeheore.PrimaryAbility && h.SecondaryAbility == removeheore.SecondaryAbility);
               _context.Remove(removeheore);

            }
             return RedirectToAction(nameof(Index));
        }
    }
}