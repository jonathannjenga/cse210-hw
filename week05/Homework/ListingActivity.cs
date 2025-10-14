using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class ListingActivity : Activity
{
    private readonly List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt peace this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

    private async Task<string?> ReadLineWithTimeoutAsync(int timeoutMs, CancellationToken ct)
    {
        var task = Task.Run(() => Console.ReadLine(), ct);
        var completed = await Task.WhenAny(task, Task.Delay(timeoutMs, ct));
        if (completed == task) return task.Result;
        return null;
    }

    protected override void Execute()
    {
        string prompt = _prompts[_rand.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.WriteLine("You will have a short time to think, then begin listing items.");
        Console.Write("Get ready: ");
        Countdown(5);

        var items = new List<string>();
        var sw = Stopwatch.StartNew();

        var cts = new CancellationTokenSource();

        while (sw.Elapsed.TotalSeconds < DurationSeconds)
        {
            int remainingMs = (int)((DurationSeconds - sw.Elapsed.TotalSeconds) * 1000);
            Console.Write($"\nItem (time left {Math.Ceiling(remainingMs / 1000.0)}s): ");
            string? line = ReadLineWithTimeoutAsync(remainingMs, cts.Token).Result;
            if (line == null)
            {
                Console.WriteLine("\nTime is up!");
                break;
            }
            if (!string.IsNullOrWhiteSpace(line))
                items.Add(line.Trim());
        }

        Console.WriteLine($"\nYou entered {items.Count} item(s).");
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]}");
        }
    }
}