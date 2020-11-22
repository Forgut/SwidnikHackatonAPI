using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwidnikHackaton.API.ViewModels
{
    public class PedestrianTraffic
    {
        public Guid SessionID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Date { get; set; }
    }
}
