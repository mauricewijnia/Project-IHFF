using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_IHFF.Models
{
    public class FilmViewModel
    {
        public int FilmId { get; set; }
        public string Actors { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
    }
}