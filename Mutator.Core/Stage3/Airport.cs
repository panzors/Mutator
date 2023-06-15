using System;
using System.Linq.Expressions;
using System.Linq;

namespace Mutator.Core.Stage3
{
    public class Passenger
    {
        public string Name { get; set; }
    }

    public record Fresh<T>(T Payload);
    public record CheckedIn<T>(T Payload);
    public record Secured<T>(T Payload);
    public record Boarded<T>(T Payload);

    public class AirportPassengerService
    {
        public CheckedIn<Passenger> CheckInAtDesk(Fresh<Passenger> freshMeat)
        {
            Console.WriteLine($"{freshMeat.Payload.Name} has checked in");
            return new CheckedIn<Passenger>(freshMeat.Payload);
        }

        public Secured<Passenger> Scan(CheckedIn<Passenger> checkedInMeat)
        {
            Console.WriteLine($"{checkedInMeat.Payload.Name} has scanned in");
            return new Secured<Passenger>(checkedInMeat.Payload);
        }

        public Secured<Passenger> VisitDutyFree(Secured<Passenger> securedMeat)
        {
            Console.WriteLine($"{securedMeat.Payload.Name} has bought some toblerones");
            return new Secured<Passenger>(securedMeat.Payload);
        }

        public Boarded<Passenger> BoardPlane(Secured<Passenger> securedMeat)
        {
            Console.WriteLine($"{securedMeat.Payload.Name} has became a human popsicle");
            return new Boarded<Passenger>(securedMeat.Payload);
        }
    }

    public static class VomitGrossExtension{
        public static (AirportPassengerService, CheckedIn<Passenger>) CheckIn(this AirportPassengerService service, Fresh<Passenger> freshMeat){
            return (service, service.CheckInAtDesk(freshMeat));
        }

        public static (AirportPassengerService, Secured<Passenger>) Scan(this (AirportPassengerService, CheckedIn<Passenger>) thing){
            return (thing.Item1, thing.Item1.Scan(thing.Item2));
        }

        public static (AirportPassengerService, Secured<Passenger>) VisitDutyFree(this (AirportPassengerService, Secured<Passenger>) thing){
            return (thing.Item1, thing.Item1.VisitDutyFree(thing.Item2));
        }

        public static Boarded<Passenger> BoardPlane(this (AirportPassengerService, Secured<Passenger>) thing){
            return thing.Item1.BoardPlane(thing.Item2);
        }

    }
}