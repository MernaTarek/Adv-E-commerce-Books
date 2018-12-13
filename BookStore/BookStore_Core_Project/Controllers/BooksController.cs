using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_Core_Project.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Books()
        {
            return View();
        }
    }
}