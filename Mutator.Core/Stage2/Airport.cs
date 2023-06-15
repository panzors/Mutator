using System;

namespace Mutator.Core.Stage2
{

    public interface ICheckedInPassenger : IPassenger
    {

        ISecuredPassenger Scan(AirportService service);
    }
    public interface ISecuredPassenger : IPassenger
    {
        ISecuredPassenger VisitDutyFree(AirportService service);
        IBoardedPassenger BoardPlane(AirportService service);
    }
    public interface IBoardedPassenger : IPassenger
    {
        IFreshPassenger Disembark(AirportService service);
    }
    public interface IFreshPassenger : IPassenger
    {
        ICheckedInPassenger CheckInAtDesk(AirportService service);
    }
    public interface IPassenger
    {
        string Name { get; }
    }

    public class Passenger : IFreshPassenger, ICheckedInPassenger, ISecuredPassenger, IBoardedPassenger
    {
        public string Name { get; set; }

        public ICheckedInPassenger CheckInAtDesk(AirportService service)
        {
            service.CheckInAtDesk(this);
            return this;
        }

        public ISecuredPassenger Scan(AirportService service)
        {
            service.Scan(this);
            return this;
        }

        public ISecuredPassenger VisitDutyFree(AirportService service)
        {
            service.VisitDutyFree(this);
            return this;
        }
        public IBoardedPassenger BoardPlane(AirportService service)
        {
            service.BoardPlane(this);
            return this;
        }

        public IFreshPassenger Disembark(AirportService service)
        {
            throw new NotImplementedException();
        }
    }

    public class AirportService
    {
        public void CheckInAtDesk(IFreshPassenger passenger)
        {
            Console.WriteLine($"{passenger.Name} has checked in");
        }

        public void Scan(ICheckedInPassenger passenger)
        {
            Console.WriteLine($"{passenger.Name} has scanned in");
        }

        public void VisitDutyFree(ICheckedInPassenger passenger)
        {
            Console.WriteLine($"{passenger.Name} has bought some toblerones");
        }

        public void BoardPlane(ICheckedInPassenger passenger)
        {
            Console.WriteLine($"{passenger.Name} has became a human popsicle");
        }
    }
}