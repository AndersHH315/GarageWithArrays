using System;

namespace Garage
{
    internal class Menu
    {
        public void MainMenu()
        {
            Console.WriteLine("1. Store a vehicle in the garage.");
            Console.WriteLine("2. Show the current vehicles in the garage.");
            Console.WriteLine("3. Search for a vehicle or vehicles.");
            Console.WriteLine("4. Remove a vehicle.");
            Console.WriteLine("0. Empty and close down the garage.");
        }

        public void VehicleMenu()
        {
            Console.WriteLine("What type of vehicle?");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Motorcycle");
            Console.WriteLine("3. Boat");
            Console.WriteLine("4. Bus");
            Console.WriteLine("5. Airplane");
        }

        public void SearchMenu()
        {
            Console.WriteLine("Select your search method");
            Console.WriteLine("1. By registernumber");
            Console.WriteLine("2. By colour");
            Console.WriteLine("3. include more then 1 property");
        }

        public void ColourMenu()
        {
            Console.WriteLine("What colour is your vehicle?");
            Console.WriteLine("1. Red");
            Console.WriteLine("2. Blue");
            Console.WriteLine("3. Green");
            Console.WriteLine("4. Yellow");
            Console.WriteLine("5. Orange");
            Console.WriteLine("6. Black");
            Console.WriteLine("7. White");
        }

        public void FuelMenu()
        {
            Console.WriteLine("What type of fuel does your vehicle consume?");
            Console.WriteLine("1. Gasoline");
            Console.WriteLine("2. Diesel");
            Console.WriteLine("3. Electricity");
        }
    }
}