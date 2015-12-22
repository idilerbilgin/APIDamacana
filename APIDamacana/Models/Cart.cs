using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace APIDamacana.Models
{
    public class Cart
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }

        public decimal TotalPrice { get; set; }
        public List<Product> Products { get; set; }
    }
}