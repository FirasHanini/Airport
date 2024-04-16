using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Inerfaces
{
    public interface IServiceFlight:IService<Flight>
    {
        IList<Staff> getStaffByFlight(int flightId);
        IList<Traveller> getTraveller(Plane plane, DateTime date);
        void DisplayNbreTraveller(DateTime date1, DateTime date2);
    }
}
