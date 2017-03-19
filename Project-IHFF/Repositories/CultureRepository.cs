using Project_IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_IHFF.Repositories
{
    public class CultureRepository
    {
      public List<MapLocations> locaties()
        {
            ModelContainer ctx = new ModelContainer();
            return ctx.MapLocationsSet.ToList();
        }

    }
}