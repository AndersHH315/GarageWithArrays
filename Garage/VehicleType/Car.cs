using System;
using Garage.VehicleType.VehicleParts;

namespace Garage.VehicleType
{
    public class Car : Vehicle
    {
        private FuelType _fuelType { get; set; }

        public FuelType FuelType
        {
            get { return _fuelType; }
            set
            {
                _fuelType = value;
            }
        }

        public Car(string registerNumber, ColourType colourType, FuelType fuelType) : 
        base(registerNumber, colourType)
        {
           FuelType = fuelType;
        }

        public override string ToString()
        { 
            return $"{ColourType} Car\nRegisternumber: {RegisterNumber} Fueltype: {FuelType.ToString().ToLower()}.";
        }
       
    }
}