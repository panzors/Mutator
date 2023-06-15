using System;

namespace Mutator.Core.Stage1 {

    public enum PassengerStatus {
        Fresh,
        CheckedIn,
        Secured,
        OnBoard,
    }

    public class Passenger {
        public string Name;
        public PassengerStatus Status;
    }

    public class CheckInDesk {
        public void CheckIn(Passenger p) {
            if (p.Status != PassengerStatus.Fresh){
                throw new Exception("You can't check in again");
            }

            p.Status = PassengerStatus.CheckedIn;
        }
    }

    public class SecurityGate {
        public void Scan(Passenger passenger){
            if (passenger.Status != PassengerStatus.CheckedIn){
                throw new Exception("Hold, you don't have a boarding pass");
            }

            passenger.Status = PassengerStatus.Secured;
        }
    }

    public class DepartureLounge {
        public void VisitDutyFree(Passenger passenger) {
            if (passenger.Status != PassengerStatus.Secured){
                throw new Exception("Security tackles you as you've snuck into the departure lounge");
            }

            // unchanged
        }

        public void BoardPlane(Passenger passenger) {
            if (passenger.Status != PassengerStatus.Secured){
                throw new Exception("You get tackled by security and you're on the tarmac in pain");
            }

            passenger.Status = PassengerStatus.OnBoard;
        }
    }

    public class Airplane {
        public void Leave(Passenger passenger) {
            if (passenger.Status != PassengerStatus.OnBoard) {
                throw new Exception("You've slipped out of the simulation somehow");
            }
        }
    }

}