using System;
using Microsoft.AspNetCore.Mvc;

namespace SwidnikHackaton.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        public string Index()
        {
            return "I'm Swidnik API and current time is: " + DateTime.Now;
        }
    }
}
