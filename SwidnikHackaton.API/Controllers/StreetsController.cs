using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SwidnikHackaton.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StreetsController : Controller
    {
        [HttpGet]
        public IEnumerable<Street> Get()
        {
            return new List<Street>()
            {
                new Street() {StreetName = "sdadsa", Latitude = (float)123.123, Longitude = (float)123.123},
                new Street() {StreetName = "sdadsa1", Latitude = (float)123.123, Longitude = (float)123.123},
                new Street() {StreetName = "sdadsa2", Latitude = (float)123.123, Longitude = (float)123.123},
            };
        }
    }

    public class Street
    {
        public string StreetName { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}


