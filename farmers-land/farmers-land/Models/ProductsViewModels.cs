using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace farmers_land.Models
{
    public class SellProduct
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Product Name:")]
        [Required(ErrorMessage ="Product namde is required.")]
        public string Name { get; set; }

        [Display(Name = "Category:")]
        [Required(ErrorMessage ="Please select a category.")]
        public string Category { get; set; }


        public string ImageName { get; set; }

        public byte[] ImageData { get; set; }

        [NotMapped]
        [Required(ErrorMessage ="Please select an image file.")]
        public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name = "Price:")]
        [Required(ErrorMessage ="A price per unit is required.")]
        public double Price { get; set; }

        [Display(Name = "Amount for sale:")]
        [Required(ErrorMessage ="Enter how much you have for  sale.")]
        public int Amount { get; set; }

        
    }
}
