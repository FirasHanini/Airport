using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Inerfaces;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class servicePlane : Service<Plane>, IServicePlain
    {
        public servicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public bool Available(int n, Flight flight)
        {
            int tickets=flight.Tickets.Count();
            int capacity = flight.myPlane.Capacity;
            return n < (capacity - tickets);
        }

        public void DeletePlaneByDate()
        {
            foreach(Plane p in GetMany(p=>DateTime.Now.Year-p.ManufactureDate.Year>10))
            {
                Delete(p);
                Commit();
            }
        }

        public IList<Flight> GetFlights(int n)
        {
            return GetAll()
                .OrderByDescending(p=>p.PlaneId)
                .Take(n).SelectMany(p=>p.Flights)
                .OrderBy(f=>f.FlightDate).ToList();
        }

        public IList<Traveller> GetTravellers(Plane plane)
        {
            return GetById(plane.PlaneId)
                .Flights.SelectMany(f=>f.Tickets)
                .Select(t=>t.MyPassenger)
                .OfType<Traveller>()
                .Distinct()
                .ToList();
        }


    }
}
