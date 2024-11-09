using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Plane
    {
        public int PlaneId { get; set; }
        public int Capacity { get; set; }
        public DateTime ManuFactureDate { get; set; }
        public PlaneType PlaneType { get; set; }

        public ICollection<Flight>? Flights { get; set; }

        public Plane()
        {
        }

        public Plane(int capacity, DateTime manuFactureDate, PlaneType planeType)
        {
            Capacity = capacity;
            ManuFactureDate = manuFactureDate;
            PlaneType = planeType;
        }

        public override string ToString()
        {
            return $"PlaneId : {PlaneId} - Capacity : {Capacity} - ManuFactureDate : {ManuFactureDate} - PlaneType : {PlaneType}";
        }
        
    }
}
