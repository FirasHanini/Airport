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
    internal class ServiceFlight : Service<Flight>, IServiceFlight
    {
        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void DisplayNbreTraveller(DateTime date1, DateTime date2)
        {
            var query = GetMany(f=>f.FlightDate>=date1 && f.FlightDate<=date2).SelectMany(f=>f.Tickets)
                .GroupBy(t=>t.MyFlight.FlightDate)
                .Select(t=>new {group=t.Key, cout=t.Count()});
            foreach(var item in query) {
                Console.WriteLine("Date de vol "+ item.group+" NBre "+item.cout);

            }
        }

        public IList<Staff> getStaffByFlight(int flightId)
        {
            return GetById(flightId).Tickets.Select(t=>t.MyPassenger).OfType<Staff>().ToList();
        }

        public IList<Traveller> getTraveller(Plane plane, DateTime date)
        {
            return Get(f => f.myPlane == plane && f.FlightDate == date)
                .Tickets.Select(t=>t.MyPassenger)
                .OfType<Traveller>().ToList();
        }
    }
}
