using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_IHFF.Models
{
    public class FilmsViewModel
    {
        public Films film;
        public List<FilmExhibitions> exhibitions;

        public FilmsViewModel()
        {
            film = new Films();
            exhibitions = new List<FilmExhibitions>();
            FilmExhibitions filmExhibition = new FilmExhibitions();
            filmExhibition.startTime = new DateTime(2016, 1, 1, 0, 0, 0);
            exhibitions.Add(filmExhibition);
            exhibitions.Add(filmExhibition);
        }
    }
}