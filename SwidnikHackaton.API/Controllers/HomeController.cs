using System;
using Microsoft.AspNetCore.Mvc;

namespace SwidnikHackaton.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public string Index()
        {
            var message = "I'm Swidnik API and current time is: " + DateTime.Now + "\n" +
                "streets/\n" +
                "coordinates/\n" +
                "measurements/<id>\n [optional ?sort==\"SpeedRatio\" to get slowest measures first] ";
            return message;

        }
    }
}
