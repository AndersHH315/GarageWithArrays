using System;
using System.Runtime.InteropServices.Marshalling;
using Garage.VehicleType.VehicleParts;

namespace Garage.VehicleType
{
    public class Vehicle
    {
        private string? _registerNumber;
        private ColourType _colourType;
        public string? RegisterNumber
        {
            get { return _registerNumber; }
            set
            {               
                _registerNumber = value;
            }
        }

        public ColourType ColourType
        {
            get { return _colourType; }
            set
            {
                _colourType = value;
            }
        }

        public Vehicle(string registerNumber, ColourType colourType)
        {
            RegisterNumber = registerNumber;
            ColourType = colourType;
        }

        public virtual new string ToString()
        {
            return $"Vehicle with the registernumber: {RegisterNumber} and colour: {ColourType}";
        }  
    }
}