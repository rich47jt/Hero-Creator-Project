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
            _context = context;
        }
        // GET: Hero
        public ActionResult Index()
        {
            return View(_context.Heroes.ToList());
        }

        // GET: Hero/Details/
        public ActionResult Details(int id)
        {
            if (id > 0)
            {
                return View(_context.Heroes.Find(id));
            }
            else
            {
                return RedirectToAction("Index");
            }
            
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
            if (id > 0)
            {
               return View(_context.Heroes.Find(id));
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        // POST: Hero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SuperHeroes heroes)
        {
            if (id > 0)
            {
               heroes = _context.Heroes.Find(id);
               _context.SaveChanges();
               return View("Index");
            }
            else
            {
               return RedirectToAction(nameof(Index));
            }
            
           
            
        }   

        // GET: Hero/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View( _context.Heroes.Find(id));
        }

        // POST: Hero/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SuperHeroes heroes)
        {
            heroes = _context.Heroes.Find(id);
            _context.Remove(heroes);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}





