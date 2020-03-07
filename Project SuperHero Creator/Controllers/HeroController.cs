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
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                NotFound();
            }
            else
            {
                _context.Heroes.Where(h => h.Id == id).FirstOrDefault();
                _context.Heroes.Find(id);
                return View(id);
            }
            return View();
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
        public ActionResult Create([Bind("Id,HeroName,AlterEgo,PrimaryAbility,SecondaryAbility,CatchPhrase")]SuperHeroes heroes)
        {
            
            _context.Heroes.Add(heroes);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));   
        } 
         
        // GET: Hero/Edit/
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                NotFound();
            }
            else
            {
                _context.Heroes.Where(h => h.Id == id).FirstOrDefault();
                _context.Heroes.Find(id);
                return RedirectToAction(nameof(Index));
            }
            return View();
            
        }

        // POST: Hero/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, [Bind("Id,HeroName,AlterEgo,PrimaryAbility,SecondaryAbility,CatchPhrase")] SuperHeroes heroes)
        {
            if (id != heroes.Id)
            {
                NotFound();
            }
            else
            {
                _context.Heroes.Update(heroes);
                _context.SaveChanges();
               return RedirectToAction(nameof(Index));
            }
            return View();
            
           
            
        }   

        // GET: Hero/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            return View( _context.Heroes.Find(id));
        }

        // POST: Hero/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, [Bind("Id,HeroName,AlterEgo,PrimaryAbility,SecondaryAbility,CatchPhrase")] SuperHeroes heroes)
        {
            if (id == null)
            {
                NotFound();
            }
            else
            {
              _context.Heroes.Find(id);
              _context.Remove(heroes);
              _context.SaveChanges();
              return RedirectToAction(nameof(Index));

            }
            return View();
        }
    }
}





