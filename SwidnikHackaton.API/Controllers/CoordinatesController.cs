using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SwidnikHackaton.API.ViewModels;

namespace SwidnikHackaton.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoordinatesController : Controller
    {
        public IEnumerable<Coordinate> Get()
        {
            var coordinates = DB2.Database.Entities.Coordinates.ToList().Select(x => new Coordinate()
            {
                StreetID = x.StreetID,
                Latitude = x.Latitude,
                Longitude = x.Longitude
            });
            return coordinates;
        }
    }

}
