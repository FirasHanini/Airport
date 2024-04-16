using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        public Action<Plane> FlightDetailsDel;
        public Action<string> DurationAverageDel;
        public FlightMethods() 
        {

            FlightDetailsDel = plane =>
            {
                var query = from f in Flights where f.myPlane == plane select f;

                foreach (var item in query)
                {
                    Console.WriteLine(item.Destination + " || " + item.FlightDate);
                }
            };
            DurationAverageDel = destination =>
            {
                var query = from f in Flights
                            where f.Destination == destination
                            select f.EstimatedDuration;
                Console.WriteLine( query.Average());

            };
        }








        public void DestinationGroupedFlights()
        {
            var query = Flights
                .GroupBy(f => f.Destination).ToList();

            foreach (var item in query)
            {
                Console.WriteLine("Destination: "+item.Key);
                foreach(var i in item)
                {
                    Console.WriteLine(i.FlightDate);

                }
            }
                        
                        
        }

        public double DurationAverage(string destination)
        {
            var query = from f in Flights where f.Destination == destination 
                        select f.EstimatedDuration;
            return query.Average();
        }

        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> dates = new List<DateTime>();
            //for(int i = 0; i<Flights.Count; i++)
            //{
            //    dates.Add(Flights[i].FlightDate);
            //}
            //
            foreach (Flight flight in Flights)
            {
                dates.Add(flight.FlightDate);
            }
            return dates;
        }

        public List<DateTime> GetFlightDatesLinQ(string destination)
        {
            var item = from f in Flights 
                       select f.FlightDate;
            return item.ToList();
        }




        public List<Flight> GetFlights(string filterType, string filterValue)
        {
            List<Flight> flights = new List<Flight>();
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.Destination == filterValue)
                        {
                            flights.Add(flight);
                        }
                    }
                    break;

                case "Departure":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.Departure == filterValue)
                        {
                            flights.Add(flight);
                        }
                    }
                    break;

                case "FlightDate":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.FlightDate == DateTime.Parse( filterValue))
                        {
                            flights.Add(flight);
                        }
                    }
                    break;




            }
            return flights;

        }

        public List<Flight> OrderedDurationFlights()
        {
            var query = from f in Flights
                        orderby f.EstimatedDuration
                        select f;
            return query.ToList();
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var query = from f in Flights where f.FlightDate >= startDate where f.FlightDate <= startDate.AddDays(7)
                        select f;
            return query.Count();
        }

   /*    public List<Traveller> SeniorTravellers(Flight flight)
        {
            return  flight.Passengers
                 .OfType<Traveller>()
                 .OrderBy(p => p.Birthdate)
                 .Take(3).ToList();


            
        }*/

        public void ShowFlightDetails(Plane plane)
        {
            var query = from f in Flights
                        where f.myPlane == plane
                        select f;
            foreach (var f in query)
            {
                Console.WriteLine(f.FlightDate + " " + f.Destination);
            }
        }

        public List<Flight> GetFlightsLinQ(string filterType, string filterValue)
        {
            List<Flight> flights = new List<Flight>();  
            switch(filterType)
            {
                case "Destination":
                    var query = from f in Flights
                                where f.Destination == filterValue
                                select f;
                    flights= query.ToList() ;
                    break;

                case "Departure":
                    var queryD = from f in Flights
                                where f.Departure == filterValue
                                select f;
                    flights=queryD.ToList() ;
                    break;
                case "FlightDate":
                    var queryF = from f in Flights
                                 where f.FlightDate==DateTime.Parse(filterValue)
                                 select f;
                    flights=queryF.ToList() ;
                    break;

            }
            return flights;
        }
    }
}
