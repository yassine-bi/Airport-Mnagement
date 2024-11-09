/* Instanciation des object */


using AM.ApplicationCore;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

//Plane plane = new Plane();
//plane.PlaneId = 1;
//plane.Capacity = 200;
//plane.ManuFactureDate = new DateTime(2018, 11, 10);
//plane.PlaneType = PlaneType.Boing;

//Console.WriteLine(plane.ToString());
/*
Plane plane = new Plane
{
    PlaneId = 1,
    Capacity = 200,
    ManuFactureDate = new DateTime(2018, 11, 10),
    PlaneType = PlaneType.Boing
};
Console.WriteLine(plane.ToString());


Passenger p1 = new Passenger();
Staff staff = new Staff();
Traveller traveller = new Traveller();
p1.PassengerType();
staff.PassengerType();
traveller.PassengerType();
*/
ServiceFlight serviceFlight = new ServiceFlight();
serviceFlight.Flights = TestData.listFlights;

//List<Flight> flights = serviceFlight.Flights;

/*
List<DateTime> flightListByDestination =  serviceFlight.getFlightDate("Paris");
foreach (var item in flightListByDestination)
{
    Console.WriteLine(item);
}
*/
/*
Console.WriteLine("List of flights by destination");
serviceFlight.GetFlights("Destination", "Paris");
Console.WriteLine("\nList of flights by FlightDate");
serviceFlight.GetFlights("FlightDate", "01/01/2022 15:10:10");
Console.WriteLine("\nList of flights by EffectiveArrival");
serviceFlight.GetFlights("EffectiveArrival", "01/01/2022 17:10:10");
*/
IEnumerable<IGrouping<string, Flight>> flightsbyDesctination = serviceFlight.DestinationGroupedFlight();