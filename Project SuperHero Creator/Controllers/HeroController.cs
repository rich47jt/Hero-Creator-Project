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
        public ActionResult Index(SuperHeroes heroes)
        {
            var theseheroes = heroes;
            theseheroes = _context.Heroes.Where(h => h.Id == theseheroes.Id && h.HeroName == theseheroes.HeroName && h.PrimaryAbility == theseheroes.PrimaryAbility && h.SecondaryAbility == theseheroes.SecondaryAbility).FirstOrDefault();
            _context.SaveChanges();
            return View(theseheroes);
        }

        // GET: Hero/Details/
        public ActionResult Details(int id)
        {
           
            _context.Heroes.Find(id);
            return View(id);
        }

        // GET: Hero/Create
        public ActionResult Create()
        {
            SuperHeroes heroes = new SuperHeroes();
            return View(heroes);
        }

        // POST: Hero/Create

        public ActionResult Create(SuperHeroes heroes)
        {
            var newhero = heroes;
            if (newhero == null)
            { 
                    _context.Heroes.Where(h => h.Id == newhero.Id && h.HeroName == newhero.HeroName && h.PrimaryAbility == newhero.PrimaryAbility && h.SecondaryAbility == newhero.SecondaryAbility).FirstOrDefault();
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                
            }  
            return View(newhero);
        }

        // GET: Hero/Edit/
        public ActionResult Edit(int id)
        {
            _context.Heroes.Find(id);
            return View(id);
        }

        // POST: Hero/Edit/5
        
        public ActionResult Edit(int id, SuperHeroes heroes)
        {
            var EditHero = heroes;
            heroes.Id = id;
            if (EditHero.Equals(id))
            {
                
               _context.Heroes.Where(h => h.Id == EditHero.Id && h.HeroName == EditHero.HeroName && h.PrimaryAbility == EditHero.PrimaryAbility && h.SecondaryAbility == EditHero.SecondaryAbility);
               _context.SaveChanges();
                return RedirectToAction(nameof(Index));
                
               
            } 
            return View(EditHero);
            
        }   

        // GET: Hero/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Hero/Delete/5
        
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}