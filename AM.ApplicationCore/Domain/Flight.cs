using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public Double EstimatedDuration { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        [ForeignKey("PlaneId")]
        public virtual Plane myPlane { get; set; }

    }
}
