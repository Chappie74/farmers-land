//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace farmers_land.Models.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductsSold
    {
        public int products_sold { get; set; }
        public string user_id { get; set; }
        public int product_id { get; set; }
        public System.DateTime date_sold { get; set; }
        public int amount { get; set; }
        public decimal price_per { get; set; }
        public string buyer_id { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
