using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_IHFF.Models
{
    public class SpecialViewModel
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Host { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public string Capacity { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}