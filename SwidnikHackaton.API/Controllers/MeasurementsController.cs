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
    public class MeasurementsController : Controller
    {
        public IEnumerable<Measurement> Get()
        {
            var measurements = DB2.Database.GetAllMeasurements().Select(x => new Measurement()
            {
                StreetID = x.StreetID,
                CurrentSpeed = x.CurrentSpeed,
                FreeFlowSpeed = x.FreeFlowSpeed,
                CurrentTravelTime = x.CurrentTravelTime,
                FreeFlowTravelTime = x.FreeFlowTravelTime,
                MeasureDate = x.MeasureDate
            });
            return measurements;
        }

        [Route("get/{id}")]
        public IEnumerable<Measurement> Get(int id)
        {
            var measurements = DB2.Database.GetAllMeasurements()
                .Where(x => x.StreetID == id)
                .Select(x => new Measurement()
            {
                StreetID = x.StreetID,
                CurrentSpeed = x.CurrentSpeed,
                FreeFlowSpeed = x.FreeFlowSpeed,
                CurrentTravelTime = x.CurrentTravelTime,
                FreeFlowTravelTime = x.FreeFlowTravelTime,
                MeasureDate = x.MeasureDate
            });
            return measurements;
        }

        [HttpGet]
        [Route("GroupedByDay/{id?}")]
        public JsonResult GroupedByDay(int? id, string sort)
        {
            var measurements = DB2.Database.GetAllMeasurements();
            if (id.HasValue)
                measurements = measurements.Where(x => x.StreetID == id);
            var result = measurements
                .ToList()
                .GroupBy(x => new { x.StreetID, x.MeasureDate.DayOfWeek, x.MeasureDate.Hour })
                .Select(x => new
                {
                    x.Key,
                    AverageCurrentSpeed = x.Average(y => y.CurrentSpeed),
                    AverageCurrentTravelTime = x.Average(y => y.CurrentTravelTime),
                    AverageFreeFlowSpeed = x.Average(y => y.FreeFlowSpeed),
                    AverageFreeFlowTraveltime = x.Average(y => y.FreeFlowTravelTime),
                    SpeedRatio = 1.00 - (x.Average(y=>y.CurrentSpeed) / x.Average(y=>y.FreeFlowSpeed))
                });
            if (sort == "SpeedRatio")
                result = result.OrderByDescending(x => x.SpeedRatio);
            return Json(result);
        }

        [HttpGet]
        [Route("GroupedByDate/{id?}")]
        public JsonResult GroupedByDate(int? id, string sort)
        {
            var measurements = DB2.Database.GetAllMeasurements();
            if (id.HasValue)
                measurements = measurements.Where(x => x.StreetID == id);
            var result = measurements 
                .ToList()
                .GroupBy(x => new { x.StreetID, x.MeasureDate.Date })
                .Select(x => new
                {
                    x.Key,
                    AverageCurrentSpeed = x.Average(y => y.CurrentSpeed),
                    AverageCurrentTravelTime = x.Average(y => y.CurrentTravelTime),
                    AverageFreeFlowSpeed = x.Average(y => y.FreeFlowSpeed),
                    AverageFreeFlowTraveltime = x.Average(y => y.FreeFlowTravelTime),
                    SpeedRatio = 1.00 - (x.Average(y => y.CurrentSpeed) / x.Average(y => y.FreeFlowSpeed))
                });
            if (sort == "SpeedRatio")
                result = result.OrderByDescending(x => x.SpeedRatio);
            return Json(result);
        }
    }
}
