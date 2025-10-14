using System;

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

    protected override void Execute()
    {
        var start = DateTime.Now;
        bool breatheIn = true;
        int interval = 4;

        while ((DateTime.Now - start).TotalSeconds < DurationSeconds)
        {
            if (breatheIn)
            {
                Console.WriteLine("\nBreathe in...");
                Countdown(interval);
            }
            else
            {
                Console.WriteLine("\nBreathe out...");
                Countdown(interval);
            }
            breatheIn = !breatheIn;
        }
    }
}
