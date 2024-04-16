using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Inerfaces
{
    public interface IServicePlain:IService<Plane>
    {
        public IList<Traveller> GetTravellers(Plane plane);
        public IList<Flight> GetFlights(int n);

        bool Available(int n , Flight flight);

        void DeletePlaneByDate();


    }
}
