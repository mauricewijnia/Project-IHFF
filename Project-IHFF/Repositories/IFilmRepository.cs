using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_IHFF.Models;

namespace Project_IHFF.Repositories
{
    interface IFilmRepository
    {
        IEnumerable<FilmViewModel> GetAllFilms();
        List<Films> GetAllFilmsToList();
        List<Exhibitions> GetAllExhibitions();
    }

    public class DbFilmRepository : IFilmRepository
    {
        private ModelContainer ctx = new ModelContainer();

        public IEnumerable<FilmViewModel> GetAllFilms()
        {
            // Dit werktals exhibitions eruit is
            /*
            var query = (from films in ctx.Films
                         join exhibitions in ctx.ExhibitionsSet on films.id equals exhibitions.filmId
                         join items in ctx.Items on films.id equals items.id
                         
                         select new FilmViewModel()
                         {
                             FilmId = films.id,
                             Actors = films.actors,
                             Name = items.name,
                             StartTime = exhibitions.startTime

                         }).ToList();

            */
            

            var query = (from x in ctx.Exhibitions
                         select new FilmViewModel()
                         {
                             StartTime = x.startTime
                         }).ToList();
            
            return query;
        } 
        
        public List<Exhibitions> GetAllExhibitions()
        {
            return ctx.Exhibitions.ToList();
        }  

        public List<Films> GetAllFilmsToList()
        {
            return ctx.Items.OfType<Films>().ToList();
        }
    }   
}