using System;
using System.Linq;
using Garage.VehicleType;
using Garage.VehicleType.VehicleParts;

namespace Garage
{
    public class Garage
    {
        private Vehicle[] _vehicles = new Vehicle[0];
        private int _arraySpots;
        Menu showMenu = new();
        string? input = "";
        public Vehicle[] Vehicles
        {
            get { return _vehicles; }
            private set
            {
                _vehicles = value;
            }
        }

        public int ArraySpots
        {
            get { return _arraySpots; }
            set
            {
                _arraySpots = value;
            }
        }

        public Garage(int arraySpots)
        {
            ArraySpots = arraySpots;
            Vehicles = new Vehicle[_arraySpots];
        }

        public Vehicle[] AddSomeVehicles(Vehicle[] vehicles)
        {
            if(vehicles.Length > 8)
            {
                Console.WriteLine("Do you want to add some vehicles to the garage? (y/n)");
                string? addVehicles = Console.ReadLine();
                while (addVehicles != "y" && addVehicles != "n")
                {
                    Console.WriteLine("Invalid input! Please enter 'y' or 'n'");
                    addVehicles = Console.ReadLine();
                }
                if(addVehicles == "y")
                {
                    vehicles[0] = new Car("ABC123", ColourType.Red, FuelType.Gasoline);
                    vehicles[1] = new Motorcycle("DEF456", ColourType.Blue, 2);
                    vehicles[2] = new Boat("GHI789", ColourType.Green, 10);
                    vehicles[3] = new Bus("JKL012", ColourType.Yellow, 50);
                    vehicles[4] = new Airplane("MNO345", ColourType.Orange, 2);
                    Console.WriteLine("5 vehicles added to the garage!");
                    ShowVehicles();
                    return vehicles;     
                }
                else
                    Console.WriteLine("Okay, no vehicles will be added to the garage!");
                    return vehicles;
            }
            return vehicles;
        }


        public Vehicle[] AddNewVehicle()
        {
            showMenu.VehicleMenu();
            input = Console.ReadLine();
            while (!int.TryParse(input, out int result) && result < 1 || result > 5)
            {
                Console.WriteLine("Wrong input! Type a number between 1-5!");
                input = Console.ReadLine();
            }           
            int choice = int.Parse(input);
            for (int i = 0; i < Vehicles.Length; i++)
            {
                if(Vehicles[i] == null)
                {
                    Vehicles[i] = ChooseVehicle(choice);
                    Console.WriteLine("Vehicle added to spot " + i);
                    return Vehicles;
                                        
                }
                else if(!Vehicles.Contains(null))
                {
                    _arraySpots++;
                    Vehicle[] newVehicles = new Vehicle[_arraySpots];
                    Array.Copy(Vehicles, newVehicles, Vehicles.Length);
                    Vehicles = newVehicles;
                    Vehicles[_arraySpots - 1] = ChooseVehicle(choice);
                    Console.WriteLine("Vehicle added to spot " + (_arraySpots - 1));
                    return Vehicles; 
                }
            }
            return Vehicles;    
        }

        public void RemoveVehicle()
        {
            string? removeVehicle = Console.ReadLine();
            if(int.TryParse(removeVehicle, out int result))
                if(Vehicles[result] != null)
                {
                    Vehicles[result] = null;
                    Console.WriteLine("Vehicle removed from spot " + result);                    
                }
                else
                    Console.WriteLine("The spot is already empty!");
        }

        public void ShowVehicles()
        {
            int car = 0, mc = 0, bus = 0, boat = 0, airplane = 0;

            for (int i = 0; i < Vehicles.Length; i++)
            {
                if(Vehicles[i] is Car)
                    car++;
                else if(Vehicles[i] is Motorcycle)
                    mc++;
                else if(Vehicles[i] is Bus)
                    bus++;
                else if(Vehicles[i] is Boat)
                    boat++;
                else if(Vehicles[i] is Airplane)
                    airplane++;
            }

            Console.WriteLine($"Total Cars: {car}\nTotal Motorcycles: {mc}\nTotal Buses: {bus}\nTotal Boats: {boat}\nTotal Airplanes: {airplane}");

            foreach (Vehicle item in Vehicles)
            {
                if(item != null)
                    Console.WriteLine(item.ToString());
            }
        }

        public Vehicle[] NormalVehicleSearch(string search)
        {           
            Vehicle[] searchResult = new Vehicle[_arraySpots];
            for (int i = 0; i < Vehicles.Length; i++)
            {
                if(Vehicles[i] != null)
                {
                    if(Vehicles[i].RegisterNumber.Contains(search, StringComparison.OrdinalIgnoreCase))
                        searchResult[i] = Vehicles[i];
                    else if(Vehicles[i].ColourType.ToString().Contains(search, StringComparison.OrdinalIgnoreCase))
                        searchResult[i] = Vehicles[i];
                }
            }
                
            return searchResult;
        }

        public Vehicle[] AdvancedVehicleSearch(string search)
        {
            Vehicle[] searchResult = new Vehicle[_arraySpots];
            var split = search.Split(' ');
            for (int i = 0; i < Vehicles.Length; i++)
            {
                if(Vehicles[i] != null)
                {
                    if(Vehicles[i] is Car && search.Contains("car", StringComparison.OrdinalIgnoreCase))
                    {
                        for (int j = 0; j < split.Length; j++)
                        {
                            if(search.Contains("car", StringComparison.OrdinalIgnoreCase) && Vehicles[i].ColourType.ToString().Contains(split[j], StringComparison.OrdinalIgnoreCase))
                                searchResult[i] = Vehicles[i];
                            else if(Vehicles[i].ColourType.ToString().Contains(split[j], StringComparison.OrdinalIgnoreCase))
                                searchResult[i] = Vehicles[i];
                            else if(Vehicles[i].RegisterNumber.Contains(split[j], StringComparison.OrdinalIgnoreCase))
                                searchResult[i] = Vehicles[i];
                        }
                    }
                    else if(Vehicles[i] is Motorcycle && search.Contains("motorcycle", StringComparison.OrdinalIgnoreCase))
                    {
                        for (int j = 0; j < split.Length; j++)
                        {
                            if(search.Contains("motorcycle", StringComparison.OrdinalIgnoreCase) && Vehicles[i].ColourType.ToString().Contains(split[j], StringComparison.OrdinalIgnoreCase))
                                searchResult[i] = Vehicles[i];
                            else if(Vehicles[i].ColourType.ToString().Contains(split[j], StringComparison.OrdinalIgnoreCase))
                                searchResult[i] = Vehicles[i];
                            else if(Vehicles[i].RegisterNumber.Contains(split[j], StringComparison.OrdinalIgnoreCase))
                                searchResult[i] = Vehicles[i];                            
                        }
                    }
                    else if(Vehicles[i] is Boat && search.Contains("boat", StringComparison.OrdinalIgnoreCase))
                    {
                        for (int j = 0; j < split.Length; j++)
                        {
                            if(search.Contains("boat", StringComparison.OrdinalIgnoreCase) && Vehicles[i].RegisterNumber.Contains(split[j], StringComparison.OrdinalIgnoreCase))
                                searchResult[i] = Vehicles[i];
                            else if(Vehicles[i].ColourType.ToString().Contains(split[j], StringComparison.OrdinalIgnoreCase))
                                searchResult[i] = Vehicles[i];
                            else if(Vehicles[i].RegisterNumber.Contains(split[j], StringComparison.OrdinalIgnoreCase))
                                searchResult[i] = Vehicles[i];                          
                        }
                    }
                    else if(Vehicles[i] is Bus && search.Contains("bus", StringComparison.OrdinalIgnoreCase))
                    {
                        for (int j = 0; j < split.Length; j++)
                        {
                            if(search.Contains("bus", StringComparison.OrdinalIgnoreCase) && Vehicles[i].RegisterNumber.Contains(split[j], StringComparison.OrdinalIgnoreCase))
                                searchResult[i] = Vehicles[i];
                            else if(Vehicles[i].ColourType.ToString().Contains(split[j], StringComparison.OrdinalIgnoreCase))
                                searchResult[i] = Vehicles[i];
                            else if(Vehicles[i].RegisterNumber.Contains(split[j], StringComparison.OrdinalIgnoreCase))
                                searchResult[i] = Vehicles[i];                            
                        }
                    }
                    else if(Vehicles[i] is Airplane && search.Contains("airplane", StringComparison.OrdinalIgnoreCase))
                    {
                        for (int j = 0; j < split.Length; j++)
                        {
                            if(search.Contains("airplane", StringComparison.OrdinalIgnoreCase) && Vehicles[i].RegisterNumber.Contains(split[j], StringComparison.OrdinalIgnoreCase))
                                searchResult[i] = Vehicles[i];
                            else if(Vehicles[i].ColourType.ToString().Contains(split[j], StringComparison.OrdinalIgnoreCase))
                                searchResult[i] = Vehicles[i];
                            else if(Vehicles[i].RegisterNumber.Contains(split[j], StringComparison.OrdinalIgnoreCase))
                                searchResult[i] = Vehicles[i];                            
                        }
                    }
                }
            }
            return searchResult;
        }

        public void SearchVehicles()
        {
            Vehicle[] searchResults = new Vehicle[_arraySpots];
            showMenu.SearchMenu();
            input = Console.ReadLine();
            while (!int.TryParse(input, out int result) && result < 1 || result > 3)
            {
                Console.WriteLine("Wrong input! Type a number between 1-3");
                input = Console.ReadLine();
            }
            int choice = int.Parse(input);
            switch (choice)
            {
                case 1:
                searchResults = RedirectVehicleSearch(choice);
                break;
                case 2:
                searchResults = RedirectVehicleSearch(choice);
                break;
                case 3:
                searchResults = RedirectVehicleSearch(choice);
                break;
                default:
                break;
            }

            Console.WriteLine("Search result: ");
            foreach (Vehicle item in searchResults)
            {
                if(item != null)
                    Console.WriteLine(item.ToString());
            }
        }

        private Car AddNewCar()
        {
            string regNmbr = RegisterNumber();
            ColourType colour = Colour();
            showMenu.FuelMenu();
            input = Console.ReadLine();
            while (!int.TryParse(input, out int result) && result < 1 || result > 3)
            {
                Console.WriteLine("Choose a fuel type between 1-3");
                input = Console.ReadLine();
            }
            int fuel = int.Parse(input);
            Car car = new(regNmbr, colour, WhatFuel(fuel));
            return car;
        }

        private Motorcycle AddNewMc()
        {
            string regNmbr = RegisterNumber();
            ColourType colour = Colour();
            Console.WriteLine("How many cylinders?");
            input = Console.ReadLine();
            while (!int.TryParse(input, out int result))
            {
                Console.WriteLine("Enter the amount of cylinders in numbers!");
                input = Console.ReadLine();
            }
            int cylinder = int.Parse(input);
            Motorcycle mc = new(regNmbr, colour, cylinder);
            return mc;
        }
        private Boat AddNewBoat()
        {
            string regNmbr = RegisterNumber();
            ColourType colour = Colour();
            Console.WriteLine("Whats the length of your boat?");
            input = Console.ReadLine();
            while (!int.TryParse(input, out int result))
            {
                Console.WriteLine("Enter the length in numbers!");
                input = Console.ReadLine();
            }
            int length = int.Parse(input);
            Boat boat = new(regNmbr, colour, length);
            return boat;
        }

        private Bus AddNewBus()
        {
            string regNmbr = RegisterNumber();
            ColourType colour = Colour();
            Console.WriteLine("How many seats does the bus ahve");
            input = Console.ReadLine();
            while (!int.TryParse(input, out int result))
            {
                Console.WriteLine("Enter the amount of seats in numbers!");
                input = Console.ReadLine();
            }
            int seats = int.Parse(input);
            Bus bus = new(regNmbr, colour, seats);
            return bus;
        }

        private Airplane AddNewAirPlane()
        {
            string regNmbr = RegisterNumber();
            ColourType colour = Colour();
            Console.WriteLine("Enter the number of engines for your ariplane.");
            input = Console.ReadLine();
            while (!int.TryParse(input, out int result))
            {
                Console.WriteLine("Enther the amount of engines in numbers!");
                input = Console.ReadLine();
            }
            int engines = int.Parse(input);
            Airplane airplane = new(regNmbr, colour, engines);
            return airplane;
        }

        private string RegisterNumber()
        {
            Console.WriteLine("Enter the registernumber for your veichle.");
            string? regNmbr = Console.ReadLine();
            while (string.IsNullOrEmpty(regNmbr) || CheckRegisterNumber(regNmbr) == false)
            {
                Console.WriteLine("Enter a valid registernumber! e.g., ABC123");
                regNmbr = Console.ReadLine();
            }
            return regNmbr;
        }

        private bool CheckRegisterNumber(string regnumber)
        {
            if(regnumber.Length > 6 || regnumber.Length < 6)
                  return false;
            else
            {
                if(char.IsNumber(regnumber[0]) || char.IsNumber(regnumber[1]) || char.IsNumber(regnumber[2]))
                    return false;
                else if(!char.IsNumber(regnumber[3]) || !char.IsNumber(regnumber[4]) || !char.IsNumber(regnumber[5]))
                    return false;
                else
                    return true;               
            }
        }

        private Vehicle[] RedirectVehicleSearch(int choice)
        {
            if(choice == 1)
            {
                Console.WriteLine("Type in a registernumber");
                input = Console.ReadLine();
                while (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Type in a registernumber! e.g., ABC123");
                    input = Console.ReadLine();
                }
                return NormalVehicleSearch(input);
            }
            else if(choice ==2)
            {
                Console.WriteLine("Type in a colour");
                input = Console.ReadLine();
                while (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Type in a colour e.g., red");
                    input = Console.ReadLine();
                }
                return NormalVehicleSearch(input);
            }
            else
                Console.WriteLine("Type in what you are searching for");
                input = Console.ReadLine();
                while (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("What are you searching for?");
                    input = Console.ReadLine();
                }
                return AdvancedVehicleSearch(input);
        }

        private ColourType Colour()
        {
            showMenu.ColourMenu();
            input = Console.ReadLine();
            while (!int.TryParse(input, out int result) && result < 1 || result > 7)
            {
                Console.WriteLine("Type a number between 1-7!");
                input = Console.ReadLine();
            }
            int colour = int.Parse(input);
            return ChooseColour(colour);
        }
        
        private Vehicle ChooseVehicle(int choice) => choice switch
        {
            1 => AddNewCar(),
            2 => AddNewMc(),
            3 => AddNewBoat(),
            4 => AddNewBus(),
            5 => AddNewAirPlane(),
            _ => throw new Exception("Invalid entry!")  
        };

        private FuelType WhatFuel(int fueltype) => fueltype switch
        {
            1 => FuelType.Gasoline,
            2 => FuelType.Diesel,
            3 => FuelType.Electricity,
            _ => throw new Exception("Invalid entry!")
        };
        private ColourType ChooseColour(int colourtype) => colourtype switch
        {
            1 => ColourType.Red,
            2 => ColourType.Blue,
            3 => ColourType.Green,
            4 => ColourType.Yellow,
            5 => ColourType.Orange,
            6 => ColourType.Black,
            7 => ColourType.White,
            _ => throw new Exception("Invalid entry!")
        };
    }
}