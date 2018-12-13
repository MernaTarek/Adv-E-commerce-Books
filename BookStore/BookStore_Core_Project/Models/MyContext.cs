using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_Core_Project.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
               : base(options)
        {

        }
        public DbSet<Models.Category> Categorys { get; set; }
        public DbSet<Models.Book> Books { get; set; }


    }
}
