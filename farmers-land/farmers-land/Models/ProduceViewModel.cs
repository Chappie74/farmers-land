using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace farmers_land.Models
{
    public class ProduceViewModel
    {
        [Display(Name = "Produce ID")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set;
        }
        [Display(Name = "Category")]
        public string Category { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Price")]
        public  double Price { get; set; }

        [Display(Name = "Seller")]
        public string Seller { get; set; }

    }


}