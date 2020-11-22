using Microsoft.AspNetCore.Mvc;
using SwidnikHackaton.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwidnikHackaton.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedestriansTrafficController : Controller
    {
        [HttpGet]
        public JsonResult Index()
        {
            var traffic = DB2.Database.GetAllPedestrianTraffics()
                .Select(x => new PedestrianTraffic()
                {
                    SessionID = x.SessionID,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    Date = x.Date
                });
            return Json(traffic);
        }

        [HttpGet]
        [Route("GetProcessedData")]
        public JsonResult GetProcessedData()
        {
            var traffic = DB2.Database.GetAllPedestrianTraffics()
                .Select(x => new PedestrianTraffic()
                {
                    SessionID = x.SessionID,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    Date = x.Date
                })
                .GroupBy(x => x.SessionID)
                .Select(x => new
                {
                    x.Key,
                    Data = x.OrderBy(y => y.Date).Select(y => new
                        { y.Latitude,
                            y.Longitude,
                            y.Date
                        })
                });
            return Json(traffic);
        }

        [HttpPost]
        [Route("Insert")]
        public JsonResult InsertNewData(Guid guid, double latitude, double longitude)
        {
            try
            {
                DB2.Database.Insert(new DB2.PedestrianTraffic()
                {
                    SessionID = guid,
                    Latitude = latitude,
                    Longitude = longitude,
                    Date = DateTime.Now
                });
                return Json("OK");
            }
            catch (Exception)
            {
                return Json("Error while inserting data");
            }
        }
    }
}
