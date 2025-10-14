using System;
using System.Collections.Generic;
class Program

{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Homework Project.");
    }
}
        var activities = new List<Activity>()
{
        {

            new BreathingActivity(),
            new ReflectionActivity(),
            new ListingActivity()

        };
{

    

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program - Main Menu");
            Console.WriteLine("1) Breathing Activity");
            Console.WriteLine("2) Reflection Activity");
            Console.WriteLine("3) Listing Activity");
            Console.WriteLine("4) Exit");
            Console.Write("\nChoose an option (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    activities[0].StartInteractive();
                    PauseToContinue();
                    break;
                case "2":
                    activities[1].StartInteractive();
                    PauseToContinue();
                    break;
                case "3":
                    activities[2].StartInteractive();
                    PauseToContinue();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }

        Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
    }

    static void PauseToContinue()
    {
        Console.WriteLine("\nPress Enter to return to the main menu...");
        Console.ReadLine();
    }
}
