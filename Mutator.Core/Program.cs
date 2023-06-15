
using System;
using Stage1 = Mutator.Core.Stage1;
using Stage2 = Mutator.Core.Stage2;
using Stage3 = Mutator.Core.Stage3;
using Mutator.Core.Stage3;

void SimulateStage1() {
    Console.WriteLine($"-----------------------------------");
    Console.WriteLine($"Simulate Stage 1");
    Console.WriteLine($"-----------------------------------");
    // Not going to inject this because reasons.
    var CheckInDesk = new Stage1.CheckInDesk();
    var SecurityGate = new Stage1.SecurityGate();
    var DepartureLounge = new Stage1.DepartureLounge();
    var Airplane = new Stage1.Airplane();

    var passenger = new Stage1.Passenger() { Name = "Normal Steve" };
    Console.WriteLine($"{passenger.Name} is {passenger.Status}");

    CheckInDesk.CheckIn(passenger);
    Console.WriteLine($"{passenger.Name} is now {passenger.Status}");

    SecurityGate.Scan(passenger);
    Console.WriteLine($"{passenger.Name} is now {passenger.Status}");

    DepartureLounge.VisitDutyFree(passenger);
    Console.WriteLine($"{passenger.Name} is now {passenger.Status}");

    DepartureLounge.BoardPlane(passenger);
    Console.WriteLine($"{passenger.Name} is now {passenger.Status}");
}


void SimulateStage2() {
    Console.WriteLine($"-----------------------------------");
    Console.WriteLine($"Simulate Stage 2");
    Console.WriteLine($"-----------------------------------");

    Stage2.IFreshPassenger passenger = new Stage2.Passenger { Name = "Fancy Pants Steve"};
    var AirportService = new Stage2.AirportService();

    var boardedPassenger = 
        passenger.CheckInAtDesk(AirportService)
            .Scan(AirportService)
            .VisitDutyFree(AirportService)
            .BoardPlane(AirportService);
}

void SimulateStage3() {
    Console.WriteLine($"-----------------------------------");
    Console.WriteLine($"Simulate Stage 3");
    Console.WriteLine($"-----------------------------------");

    var passenger = new Stage3.Passenger { Name = "Encapsulated Steve"};
    var AirportService = new Stage3.AirportPassengerService();

    var boardedPassenger = AirportService.CheckIn(new Stage3.Fresh<Stage3.Passenger>(passenger))
        .Scan()
        .VisitDutyFree()
        .BoardPlane();
}

SimulateStage1();
SimulateStage2();
SimulateStage3();