using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace farmers_land.Models
{
    public class Produce
    {
        public int Id { get; set; }
        [Display(Name="Name:")]
        public string Name { get; set; }
        [Display(Name = "Category:")]
        public string Category { get; set; }
        [Display(Name = "Quantity:")]
        public int Quantity { get; set; }
        [Display(Name = "Price:")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

    }
}