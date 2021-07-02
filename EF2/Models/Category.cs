using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF2.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set;}
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
    }
}