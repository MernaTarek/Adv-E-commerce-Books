using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore_Core_Project.Models;

namespace BookStore_Core_Project.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly MyContext _context;

        public CategoriesController(MyContext context)
        {
            _context = context;
        }

        // GET: Categories
        public IActionResult Index()
        {
            return View( _context.Categorys.ToList());
        }

      

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        
        public IActionResult Create(Category category)
        {
            
                _context.Add(category);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Categories/Edit/5
        public IActionResult Edit(int id)
        {
           

            var category =  _context.Categorys.Find(id);
         
            return View(category);
        }

        // POST: Categories/Edit/5
        
        [HttpPost]
        
        public IActionResult Edit(Category category)
        {
            

          
                    _context.Update(category);
                     _context.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Categories/Delete/5
        public IActionResult Delete(int id)
        {
            var category = _context.Categorys.Find(id);
            _context.Categorys.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
