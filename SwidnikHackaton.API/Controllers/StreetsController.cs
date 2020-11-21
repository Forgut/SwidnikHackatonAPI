using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwidnikHackaton.API.ViewModels;

namespace SwidnikHackaton.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StreetsController : Controller
    {
        [HttpGet]
        public IEnumerable<Street> Get()
        {
            var streets = DB2.Database.Entities.Streets.ToList().Select(x => new Street()
            {
                ID = x.ID,
                StreetName = x.StreetName,
                Latitude = x.Latitude,
                Longitude = x.Longitude
            });
            return streets;
        }

        [HttpGet]
        [Route("{id}")]
        public Street Get(int id)
        {
            var street = DB2.Database.Entities.Streets.FirstOrDefault(x => x.ID == id);
            return new Street()
            {
                ID = street.ID,
                StreetName = street.StreetName,
                Latitude = street.Latitude,
                Longitude = street.Longitude
            };
        }
    }

 
}


