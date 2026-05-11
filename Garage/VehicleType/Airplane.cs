using System;
using Garage.VehicleType.VehicleParts;

namespace Garage.VehicleType
{
    public class Airplane : Vehicle
    {
        private int _numberOfEngines { get; set; }
        public int NumberOfEngines
        {
            get { return _numberOfEngines; }
            set
            {
                _numberOfEngines = value;
            }
        }
        public Airplane(string registerNumber, ColourType colourType, int numberOfEngines) : 
        base(registerNumber, colourType)
        {
            NumberOfEngines = numberOfEngines;
        }

        public override string ToString()
        {
            return $"{ColourType} Airplane\nRegisternumber: {RegisterNumber} Amount of engines: {NumberOfEngines}.";
        }
    }
}