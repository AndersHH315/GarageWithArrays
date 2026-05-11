using System;

namespace Garage
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu showMenu = new();
            string? input = "";
            Console.WriteLine("Create a garage by enter the amount of spots in numbers!");
            string? spots = Console.ReadLine();
            while (!int.TryParse(spots, out int check))
            {
                Console.WriteLine("Type a number between 0-3!");
                spots = Console.ReadLine();
            }
            Garage garage = new(int.Parse(spots));
            garage.AddSomeVehicles(garage.Vehicles);
            do
            {
                showMenu.MainMenu();
                input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                    Console.WriteLine("Closing down the garage!");
                    break;
                    case "1":
                    garage.AddNewVehicle();
                    break;
                    case "2":
                    garage.ShowVehicles();
                    break;
                    case "3":
                    garage.SearchVehicles();
                    break;
                    case "4":
                    garage.RemoveVehicle();
                    break;
                    default:
                    Console.WriteLine("Invalid entry! Try again!");
                    break;
                }                    
            } while (input != "0");
        }
    }
}

