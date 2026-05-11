using Garage.VehicleType.VehicleParts;

namespace Garage.VehicleType
{
    public class Motorcycle : Vehicle
    {
        private int _cylinderVolume;

        public int CylinderVolume
        {
            get { return _cylinderVolume; }
            set
            {
                _cylinderVolume = value;
            }
        }
        public Motorcycle(string registerNumber, ColourType colourType, int cylinderVolume) : 
        base(registerNumber, colourType)
        {
            CylinderVolume = cylinderVolume;
        }

        public override string ToString()
        {
            return $"{ColourType} Motorcycle\nRegisternumber: {RegisterNumber} Amount of cylinders: {CylinderVolume}.";
        }
    }
}