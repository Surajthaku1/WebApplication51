using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication51.Models
{
    public class products
    {
        public int Id { get; set; }
        public string Myproperty { get; set; }
        public int Quantity { get; set; }
         
        public int Price { get; set; }
        public string Description { get; set; }
        public category category { get; set; }


    }
}