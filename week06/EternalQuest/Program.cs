
using System;
using System.IO;



class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");
    }
}
class Program
{
    static void Main(string[] args)
    {
        var manager = new GoalManager();
        const string savePath = "goals_save.txt";

        if (!File.Exists(savePath))
        {
            Console.WriteLine("No save found — creating sample goals.");
            manager.AddGoal(new EternalGoal("Read Scriptures", "Daily scripture study", 100));
            manager.AddGoal(new SimpleGoal("Run Marathon", "Complete a marathon", 1000));
            manager.AddGoal(new ChecklistGoal("Attend Temple", "Go to the temple", 50, 10, 500));
        }
        else
        {
            manager.LoadFromFile(savePath);
        }

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nEternal Quest - Main Menu");
            Console.WriteLine("1. Show Goals");
            Console.WriteLine("2. Create New Goal");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Show Score & Badges");
            Console.WriteLine("5. Save");
            Console.WriteLine("6. Load");
            Console.WriteLine("7. Exit");
            Console.Write("Choose: ");

            var input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1": manager.ShowGoals(); break;
                case "2": CreateGoalInteractive(manager); break;
                case "3":
                    manager.ShowGoals();
                    Console.Write("Enter goal number: ");
                    if (int.TryParse(Console.ReadLine(), out int gnum))
                        manager.RecordEventForGoal(gnum - 1);
                    break;
                case "4": manager.ShowStatus(); break;
                case "5": manager.SaveToFile(savePath); break;
                case "6": manager.LoadFromFile(savePath); break;
                case "7":
                    manager.SaveToFile(savePath);
                    running = false;
                    break;
                default: Console.WriteLine("Invalid option."); break;
            }
        }
    }

    static void CreateGoalInteractive(GoalManager manager)
    {
        Console.WriteLine("Choose Goal Type: 1) Simple 2) Eternal 3) Checklist");
        Console.Write("Type (1/2/3): ");
        var type = Console.ReadLine();

        Console.Write("Enter name: ");
        var name = Console.ReadLine() ?? "";
        Console.Write("Enter description: ");
        var desc = Console.ReadLine() ?? "";
        Console.Write("Enter points: ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid points.");
            return;
        }

        switch (type)
        {
            case "1":
                manager.AddGoal(new SimpleGoal(name, desc, points));
                break;
            case "2":
                manager.AddGoal(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Enter target: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus: ");
                int bonus = int.Parse(Console.ReadLine());
                manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                break;
        }
    }
}
