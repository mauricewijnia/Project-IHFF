using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_IHFF.Models
{
    public class FilmsViewModel
    {
        public Films film;
        public FilmExhibitions exhibitionA;
        public FilmExhibitions exhibitionB;

        public FilmsViewModel()
        {
            film = new Films();

            exhibitionA = new FilmExhibitions();
            exhibitionA.startTime = new DateTime(2016, 1, 1, 0, 0, 0);
        }
        
    }
}