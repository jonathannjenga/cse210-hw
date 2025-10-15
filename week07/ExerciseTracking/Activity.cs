using System;

public abstract class Activity
{
    private DateTime _date;
    private int _length; // in minutes

    public Activity(DateTime date, int length)
    {
        _date = date;
        _length = length;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public int GetLength()
    {
        return _length;
    }

    // Abstract methods for polymorphism
    public abstract double GetDistance(); // km
    public abstract double GetSpeed();    // kph
    public abstract double GetPace();     // min per km

    public virtual string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} {GetType().Name} ({_length} min): " +
               $"Distance {GetDistance():0.0} km, Speed {GetSpeed():0.0} kph, Pace {GetPace():0.0} min per km";
    }
}