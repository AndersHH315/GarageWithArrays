using Garage.VehicleType.VehicleParts;

namespace Garage.VehicleType
{
    public class Boat : Vehicle
    {
        private int _length { get; set; }
        public int Length
        {
            get { return _length; }
            set
            {
                _length = value;
            }
        }
        public Boat(string registerNumber, ColourType colourType, int length) : 
        base(registerNumber, colourType)
        {
            Length = length;
        }

        public override string ToString()
        {
            return $"{ColourType} Boat\nRegisternumber: {RegisterNumber} The boat length: {Length}m.";
        }
    }
}