using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight
    {
        List<DateTime> getFlightDate(string destination);

        void GetFlights(string filterType, string filerValue);

        void ShowFlightDetails(Plane plane);

        int ProgrammedFlightNumber(DateTime startDate);

        double DurationAverage(string destination);

        List<Flight> OrderedDurationFlights();

        List<Passenger> SeniorTravallers(Flight flight);
        IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlight();
    }
}
