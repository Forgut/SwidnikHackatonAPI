using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwidnikHackaton.API.ViewModels
{
    public class Street
    {
        public int ID { get; set; }
        public string StreetName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
