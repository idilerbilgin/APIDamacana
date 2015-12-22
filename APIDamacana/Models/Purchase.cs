using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace APIDamacana.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<Product> PurchaseList { get; set; }

        public decimal TotalPrice { get; set; }


    }
}