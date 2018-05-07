using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace farmers_land.Models
{
    public class CartViewModel
    {
        public int ID {get;set;}

        public ProduceViewModel Produce {get;set;}

        public byte Image { get; set; }

        public int Total_Items { get; set; }

        public double Total { get; set; }
    }
}