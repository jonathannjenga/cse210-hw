using System;
using System.Threading;

abstract class Activity
{
    private string _name;
    private string _description;
    private int _durationSeconds;
    protected static readonly Random _rand = new Random();

    public string Name => _name;
    public string Description => _description;
    public int DurationSeconds => _durationSeconds;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartInteractive()
    {
        Console.Clear();
        Console.WriteLine($"--- {Name} ---");
        Console.WriteLine(Description);
        Console.WriteLine();

        _durationSeconds = PromptForDuration();
        Console.WriteLine("\nGet ready...");
        PauseWithSpinner(3);

        Execute();

        Console.WriteLine();
        Console.WriteLine("Well done!");
        Console.WriteLine($"You completed the {Name} for {DurationSeconds} seconds.");
        PauseWithSpinner(3);
    }

    protected abstract void Execute();

    protected int PromptForDuration()
    {
        while (true)
        {
            Console.Write("Enter duration in seconds: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int secs) && secs > 0)
                return secs;
            Console.WriteLine("Please enter a valid number of seconds.");
        }
    }

    protected void PauseWithSpinner(int seconds)
    {
        char[] spinner = { '|', '/', '-', '\\' };
        var start = DateTime.Now;
        int i = 0;
        while ((DateTime.Now - start).TotalSeconds < seconds)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(200);
            Console.Write('\b');
            i++;
        }
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void SpinnerFor(int seconds, int intervalMs = 400)
    {
        char[] spinner = { '|', '/', '-', '\\' };
        var start = DateTime.Now;
        int i = 0;
        while ((DateTime.Now - start).TotalSeconds < seconds)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(intervalMs);
            Console.Write('\b');
            i++;
        }
    }
}
