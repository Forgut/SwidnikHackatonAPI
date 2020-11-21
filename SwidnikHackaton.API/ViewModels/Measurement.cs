using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwidnikHackaton.API.ViewModels
{
    public class Measurement
    {
        public Measurement()
        {

        }
        public Measurement(DB2.Measurements measurement)
        {
            StreetID = measurement.StreetID;
            CurrentSpeed = measurement.CurrentSpeed;
            FreeFlowSpeed = measurement.FreeFlowSpeed;
            CurrentTravelTime = measurement.CurrentTravelTime;
            FreeFlowTravelTime = measurement.FreeFlowTravelTime;
            MeasureDate = measurement.MeasureDate;
        }
        public int StreetID { get; set; }
        public int CurrentSpeed { get; set; }
        public int FreeFlowSpeed { get; set; }
        public int CurrentTravelTime { get; set; }
        public int FreeFlowTravelTime { get; set; }
        public DateTime MeasureDate { get; set; }
    }
}
