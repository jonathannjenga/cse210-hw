using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");
    }
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2025, 11, 3), 30, 4.8),
            new Cycling(new DateTime(2025, 11, 3), 40, 15.0),
            new Swimming(new DateTime(2025, 11, 3), 25, 30)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
