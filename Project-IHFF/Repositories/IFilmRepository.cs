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
        IEnumerable<ExhibitionViewModel> GetAllFilms();
        IEnumerable<ExhibitionViewModel> GetFilmsByDay(int day);
        List<Films> GetAllFilmsToList();
        List<Exhibitions> GetAllExhibitions();
    }

    public class DbFilmRepository : IFilmRepository
    {
        private ModelContainer ctx = new ModelContainer();

        public IEnumerable<ExhibitionViewModel> GetAllFilms()
        {
            var query = (from films in ctx.Items.OfType<Films>()
                         join exhibitions in ctx.Exhibitions on films.id equals exhibitions.filmId
                         join items in ctx.Items on films.id equals items.id
                         orderby exhibitions.startTime ascending
                         select new ExhibitionViewModel()
                         {
                             FilmId = films.id,
                             ExhibitionId = exhibitions.id,
                             Name = items.name,
                             Description = items.description,
                             Director = films.director,
                             Actors = films.actors,
                             Image = items.imagePath,
                             Location = items.location,
                             Price = items.price,
                             Capacity = films.capacity,
                             StartTime = exhibitions.startTime,
                             EndTime = exhibitions.endTime
                         }).ToList();
            return query;
        }

        public IEnumerable<ExhibitionViewModel> GetFilmsByDay(int day)
        {
            var query = (from films in ctx.Items.OfType<Films>()
                         join exhibitions in ctx.Exhibitions on films.id equals exhibitions.filmId
                         join items in ctx.Items on films.id equals items.id
                         where SqlFunctions.DatePart("dw", exhibitions.startTime) == day
                         orderby exhibitions.startTime ascending

                         select new ExhibitionViewModel()
                         {
                             FilmId = films.id,
                             ExhibitionId = exhibitions.id,
                             Name = items.name,
                             Description = items.description,
                             Director = films.director,
                             Actors = films.actors,
                             Image = items.imagePath,
                             Location = items.location,
                             Price = items.price,
                             Capacity = films.capacity,
                             StartTime = exhibitions.startTime,
                             EndTime = exhibitions.endTime

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