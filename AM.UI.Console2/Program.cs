// See https://aka.ms/new-console-template for more information






using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;


Plane plane = new Plane
{
    PlaneId= 1,
    Capacity=500,
   ManufactureDate= DateTime.Now
};

Console.WriteLine(plane);

Passenger passenger = new Passenger
{
    FullName=new FullName{
    FirstName = "Firas",
    LastName = "Hanini"
    }
};
Console.WriteLine(passenger.CheckProfile("Firas","Hanini",null));

Staff staff = new Staff
{
    FullName =new FullName
    {
        FirstName = "aa",
        LastName = "bb"
    }
};
passenger.PassengerType();
staff.PassengerType();

Console.WriteLine("////////////////////////////////////////////////////////////////////////////////");

FlightMethods flightMethods=new FlightMethods
{
    Flights=TestDATA.listFlights
};


AMContext am = new AMContext { };
/*
am.Flights.Add(TestDATA.flight2);
am.SaveChanges();
*/

Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
Console.WriteLine(am.Flights.First().myPlane.Capacity);



