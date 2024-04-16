using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Plane = AM.ApplicationCore.Domain.Plane;


namespace AM.UI.Console
{
    public class Program
    {

        Plane plane = new Plane
        {
            PlaneId = 1,
            Capacity = 50,
            ManufactureDate = DateTime.Now
        };



    }
}
