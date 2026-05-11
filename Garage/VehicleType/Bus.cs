using System;
using Garage.VehicleType.VehicleParts;

namespace Garage.VehicleType
{
    public class Bus : Vehicle
    {
        private int _numberOfSeats { get; set; }

        public int NumberOfSeats
        {
            get { return _numberOfSeats; }
            set
            {
                _numberOfSeats = value;
            }
        }
        public Bus(string registerNumber, ColourType colourType, int numberOfSeats) : 
        base(registerNumber, colourType)
        {
            NumberOfSeats = numberOfSeats;
        }

        public override string ToString()
        {
            return $"{ColourType} Bus\nRegisternumber: {RegisterNumber} Number of seats: {NumberOfSeats}.";
        }
    }
}