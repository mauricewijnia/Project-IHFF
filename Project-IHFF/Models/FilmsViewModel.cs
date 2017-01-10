using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_IHFF.Models
{
    public class FilmsViewModel
    {
        public Films film { get; set; }
        public List<Exhibitions> exhibitions { get; set; }
        

        public FilmsViewModel()
        {
            
            film = new Films();
            exhibitions = new List<Exhibitions>();
            
        }       
    }
}