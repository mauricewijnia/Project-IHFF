using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_IHFF.Models
{
    public class RestaurantViewModel
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public TimeSpan TimeOpen { get; set; }
        public TimeSpan TimeClosed { get; set; }
    }
}