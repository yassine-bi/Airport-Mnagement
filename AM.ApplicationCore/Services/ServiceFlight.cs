using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight: IServiceFlight
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();


        /*
public List<DateTime> getFlightDate(string destination)
{
   List<DateTime> dateTimeFlight = new List<DateTime>();

   foreach (var flight in Flights)
   {
       if (flight.Destination == destination)
       {
           dateTimeFlight.Add(flight.FlightDate);
       }
   }
   for (int i = 0; i < Flights.Count; i++)
   {
       if (Flights[i].Destination == destination)
       {
           dateTimeFlight.Add(Flights[i].FlightDate);
       }
   }
   return dateTimeFlight;
}*/

        public List<DateTime> getFlightDate(string destination)
        {
            List<DateTime> dateTimeFlight = new List<DateTime>();
            List<DateTime> dateTimeFlight2 = new List<DateTime>();
            dateTimeFlight = Flights.Where(f => f.Destination == destination).Select(f => f.FlightDate).ToList();
            dateTimeFlight2 = (from f in Flights
                            where f.Destination == destination
                            select f.FlightDate).ToList();
            return dateTimeFlight2;
        }

        public void GetFlights(string filterType, string filerValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (var flight in Flights)
                    {
                        if (flight.Destination == filerValue)
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "FlightDate":
                    foreach (var flight in Flights)
                    {
                        DateTime date = DateTime.Parse(filerValue);
                        if (flight.FlightDate == date)
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "EffectiveArrival":
                    foreach (var flight in Flights)
                    {
                        DateTime date = DateTime.Parse(filerValue);
                        if (flight.EffectiveArrival == date)
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var query = from flight in Flights
                        where DateTime.Compare(flight.FlightDate, startDate) > 0 
                        && (flight.FlightDate - startDate).TotalDays <= 7
                        select flight;

            var query2 = Flights.Where(f => DateTime.Compare(f.FlightDate, startDate) > 0 
                                   && (f.FlightDate - startDate).TotalDays <= 7);
            return query.Count();
        }

        public void ShowFlightDetails(Plane plane)
        {
            // Afficher les dates et les destinations des vols d’un avion
            var query = from flight in Flights
                        where flight.Plane.PlaneId == plane.PlaneId
                        select new { flight.FlightDate, flight.Destination };
            //shwo
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }


        public double DurationAverage(string destination)
        {
            var query = (from flight in Flights
                        where flight.Destination == destination
                        select flight.EstimatedDuration).Average();

            var query2 = Flights.Where(f => f.Destination == destination).Select(f => f.EstimatedDuration).Average();

            return query2;
        }

        public List<Flight> OrderedDurationFlights()
        {
            var query = from flight in Flights
                        orderby flight.EstimatedDuration
                        select flight;

            var query2 = Flights.OrderBy(f => f.EstimatedDuration);
            var result = new List<Flight>();
            foreach (var item in query)
            {
                result.Add(item);
            }
            return result;
        }

        public List<Passenger> SeniorTravallers(Flight flight)
        {
            //select the older 3 travailleur (traveller is a class extends passanger)
            var query = (from passenger in flight.Passengers
                        where passenger is Traveller
                        orderby passenger.BirthDate
                        select passenger).Take(3);
            var query2 = flight.Passengers.Where(p => p is Traveller).OrderBy(p => p.BirthDate).Take(3);
            var query3 = flight.Passengers.OfType<Traveller>().OrderBy(p => p.BirthDate).Take(3);
            var result = new List<Passenger>();
            foreach (var item in query)
            {
                result.Add(item);
            }
            return query2.ToList();
        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlight()
        {
            var query = from flight in Flights
                        group flight by flight.Destination;
            foreach (var item in query)
            {
                Console.WriteLine("Destination {0}", item.Key);
                foreach (var flight in item)
                {
                    Console.WriteLine("Décollage {0}", flight.FlightDate);
                }
            }
            return query;
        }
    }
}
