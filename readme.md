# Mutator

Created for the express purpose of conducting and interesting experiment with mutators

## What is this trying to solve?

Not sure yet. A way to programatically bake in validation pipeline such that people don't muck things up when they go and fiddle with services


## Examples

This project uses an airport-like control structure.

You have your passenger who goes from entrance of the airport, Passenger which then ChecksIn_Passenger, then Departure lounge security gate. Then boarding the plane ready to be shipped off
The state diagram is pretty simple. You can do various things at each stage but you're technically still a user right?

Lets assume this is a weird airport and these are some actions you can do. You can't do some actions in some states so you'll have to program them in.
- Passenger.CheckIn
- Passenger.GoToDepartureLounge
- Passenger.VisitDutyFree
- Passenger.BoardPlane
- Passenger.DisembarkPlane


### Stage 1
