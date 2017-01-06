using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_IHFF.Models
{
    public class FilmsViewModel
    {
        public Films film { get; set; }

        public Exhibitions exhibitionA { get; set; }
        public Exhibitions exhibitionB { get; set; }


        public FilmsViewModel()
        {
            film = new Films();
            exhibitionA = new Exhibitions();
            exhibitionB = new Exhibitions();
        }
        
    }
}