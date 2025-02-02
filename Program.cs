using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aktiveringsuppgift_Programmering_2
{
    internal class Program
    {
        // Deklarera en array med 5 bilmärken
        static string[] cars = { "Volvo", "BMW", "Ford", "Mazda", "Audi" };

        static void Main(string[] args)
        {
            bool running = true;

            // While-loop som håller programmet igång tills användaren väljer att avsluta
            while (running)
            {
                // Visa menyn och få användarens val
                Console.WriteLine("Välj ett alternativ:");
                Console.WriteLine("1. Visa alla fordon");
                Console.WriteLine("2. Ersätt ett fordon");
                Console.WriteLine("3. Avsluta");
                string input = Console.ReadLine(); // Läser användarens val

                switch (input)
                {
                    case "1":
                        // Anropa metoden för att visa alla fordon
                        DisplayCars();
                        break;
                    case "2":
                        // Anropa metoden för att ersätta ett fordon
                        ReplaceCar();
                        break;
                    case "3":
                        // Avsluta programmet
                        running = false;
                        Console.WriteLine("Avslutar programmet...");
                        break;
                    default:
                        Console.WriteLine("Felaktigt val, försök igen.");
                        break;
                }

                Console.WriteLine(); // Ger lite mellanrum mellan varje menyvisning
            }
        }

        // Metod för att visa alla fordon i arrayen
        static void DisplayCars()
        {
            Console.WriteLine("Nuvarande fordon i listan:");

            // For-loop för att skriva ut varje fordon i arrayen
            for (int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {cars[i]}");
            }
        }

        // Metod för att ersätta ett fordon i arrayen
        static void ReplaceCar()
        {
            // Visa nuvarande fordon med en foreach-loop
            Console.WriteLine("Vilket fordon vill du ersätta? (ange nummer 1-5):");

            int index = 1;
            foreach (var car in cars)
            {
                Console.WriteLine($"{index}. {car}");
                index++;
            }

            // Hämta användarens val och validera att det är ett giltigt nummer
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= cars.Length)
            {
                Console.WriteLine($"Du valde att ersätta {cars[choice - 1]}. Ange det nya fordonet:");
                string newCar = Console.ReadLine(); // Läser in det nya fordonet
                cars[choice - 1] = newCar; // Ersätter fordonet på vald plats
                Console.WriteLine($"Fordonet på plats {choice} har ersatts med {newCar}.");
            }
            else
            {
                Console.WriteLine("Felaktigt val, försök igen.");
            }
        }
    }
}
