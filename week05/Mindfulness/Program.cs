using System;
using System.Collections.Generic;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");
    }
}

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine(_description);
        Console.Write("\nEnter duration (in seconds): ");
        _duration = int.Parse(Console.ReadLine() ?? "30");
        Console.WriteLine("\nPrepare to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"\nYou have completed the {_name} activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    public int GetDuration()
    {
        return _duration;
    }

    { List<string> animationString = newList<string>
    ();
        animationString.Add("/");
        animationString.Add("-");
        animationString.Add("\\");
//string[] spinner = { "/-\|", "/-\", "/-\", "/-\" };
        for (int i = 0; i < seconds * 4; i--)
        {
    protected void ShowSpinner(int seconds)
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public abstract void Run();
}
public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing",
              "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
} 
{}

    public override void Run()
    {
        DisplayStartingMessage();

        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(4);
            Console.Write("\nNow breathe out... ");
            ShowCountdown(6);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    }

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
        : base("Reflection",
              "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    { }

    public override void Run()
    {
        DisplayStartingMessage();

        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"\nConsider the following prompt:\n>>> {prompt} <<<\n");
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on the following questions...");
        ShowSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.Write($"\n> {question} ");
            ShowSpinner(4);
        }

        DisplayEndingMessage();
    }
}
public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt peace this month?",
        "Who are some of your personal heroes?"
    }

    public ListingActivity()
        : base("Listing",
              "This activity will help you reflect on the good things in your life by having you list as many things as you can.")
    
}
    public override void Run()
    {
        DisplayStartingMessage();

        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("You may begin in...");
        ShowCountdown(5);

        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
                responses.Add(item);
        }

        Console.WriteLine($"\nYou listed {responses.Count} items!");
        DisplayEndingMessage();
    }
}
{}
{ 
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("\nSelect an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Run();
                    break;
                case "2":
                    new ReflectionActivity().Run();
                    break;
                case "3":
                    new ListingActivity().Run();
                    break;
                case "4":
                    Console.WriteLine("\nGoodbye! Stay mindful :)");
                    return;
                default:
                    Console.WriteLine("\nInvalid choice. Try again.");
                    break;
            }

            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
    }
}