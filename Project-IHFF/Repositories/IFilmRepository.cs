using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_IHFF.Models;
using System.Data.Entity.SqlServer;

namespace Project_IHFF.Repositories
{
    interface IFilmRepository
    {
        IEnumerable<FilmViewModel> GetAllFilms();
        IEnumerable<FilmViewModel> GetFilmsByDay(int day);
        List<Films> GetAllFilmsToList();
        List<Exhibitions> GetAllExhibitions();
    }

    public class DbFilmRepository : IFilmRepository
    {
        private ModelContainer ctx = new ModelContainer();

        public IEnumerable<FilmViewModel> GetAllFilms()
        {
            // +1 want dateTime in query pakt een dag verder
            //var day = ((int)DayOfWeek.Friday)+1;
            // Dit werktals exhibitions eruit is
            var query = (from films in ctx.Items.OfType<Films>()
                         join exhibitions in ctx.Exhibitions on films.id equals exhibitions.filmId
                         join items in ctx.Items on films.id equals items.id
                         //where SqlFunctions.DatePart("dw", exhibitions.startTime) == day
                         orderby exhibitions.startTime ascending


                         select new FilmViewModel()
                         {
                             FilmId = films.id,
                             Actors = films.actors,
                             Name = items.name,
                             StartTime = exhibitions.startTime

                         }).ToList();
            return query;
        }
        public IEnumerable<FilmViewModel> GetFilmsByDay(int day)
        {
            var query = (from films in ctx.Items.OfType<Films>()
                         join exhibitions in ctx.Exhibitions on films.id equals exhibitions.filmId
                         join items in ctx.Items on films.id equals items.id
                         where SqlFunctions.DatePart("dw", exhibitions.startTime) == day
                         //orderby exhibitions.startTime ascending

                         select new FilmViewModel()
                         {
                             FilmId = films.id,
                             Actors = films.actors,
                             Name = items.name,
                             StartTime = exhibitions.startTime

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