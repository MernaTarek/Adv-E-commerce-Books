using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_Core_Project.Models
{
    public class Book
    {

        [Key]
        public int BookID { get; set; }


        public string Name { get; set; }


        public decimal Price { get; set; }
        
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Category  Category   {get; set;}
        
    }
}
