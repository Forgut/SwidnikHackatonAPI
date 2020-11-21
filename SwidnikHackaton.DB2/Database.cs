using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwidnikHackaton.DB2
{
    public static class Database
    {
        private static Swidnik2Entities _entities;
        public static Swidnik2Entities Entities
        {
            get
            {
                if (_entities == null)
                    _entities = new Swidnik2Entities();
                return _entities;
            }
        }

        public static IQueryable<Streets> GetAllStreets()
        {
            return Entities.Streets;
        }
        public static IQueryable<Coordinates> GetAllCoordinates()
        {
            return Entities.Coordinates;
        }
        public static IQueryable<Measurements> GetAllMeasurements()
        {
            return Entities.Measurements;
        }
    }
}
