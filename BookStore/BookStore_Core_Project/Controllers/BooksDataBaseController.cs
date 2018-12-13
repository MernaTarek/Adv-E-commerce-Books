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
    public class BooksDataBaseController : Controller
    {
        private readonly MyContext _context;

        public BooksDataBaseController(MyContext context)
        {
            _context = context;
        }

        // GET: BooksDataBase
        public IActionResult Index()
        {
            var myContext = _context.Books.Include(b => b.Category);
            return View( myContext.ToList());
        }

      

        // GET: BooksDataBase/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categorys, "CategoryID", "CategoryID");
            return View();
        }

        // POST: BooksDataBase/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public IActionResult Create([Bind("BookID,Name,Price,CategoryID")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categorys, "CategoryID", "CategoryID", book.CategoryID);
            return View(book);
        }

        // GET: BooksDataBase/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book =  _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categorys, "CategoryID", "CategoryID", book.CategoryID);
            return View(book);
        }

        // POST: BooksDataBase/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("BookID,Name,Price,CategoryID")] Book book)
        {
            if (id != book.BookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookID))
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
            ViewData["CategoryID"] = new SelectList(_context.Categorys, "CategoryID", "CategoryID", book.CategoryID);
            return View(book);
        }

        // GET: BooksDataBase/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book =  _context.Books
                .Include(b => b.Category)
                .FirstOrDefault(m => m.BookID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: BooksDataBase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book =  _context.Books.Find(id);
            _context.Books.Remove(book);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookID == id);
        }
    }
}
