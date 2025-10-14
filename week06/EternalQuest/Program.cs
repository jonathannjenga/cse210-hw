
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");
    }
}
abstract class Goal
{
    // Common fields that are encapsulated
    private string _name;
    private string _description;
    private int _points; // points awarded per completion event (for simple, eternal, or each checklist tick)

    // Expose read-only properties where appropriate
    public string Name => _name;
    public string Description => _description;
    public int Points => _points;

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    // Return a display string for list of goals. Derived classes can override for extra info.
    public virtual string GetDetailsString()
    {
        // Default: show name, description, point value
        return $"{Name} ({Description}) - {Points} pts each";
    }

    // Abstract method forces derived classes to implement how they record an event
    // and return how many points the user earned as a result of this record.
    public abstract int RecordEvent();

    // Save format (derived classes append their own fields)
    // e.g. Simple|Name|Desc|Points|IsComplete
    public abstract string Serialize();

    // Optional factory parse method to reconstruct from saved text
    public static Goal Deserialize(string line)
    {
        // Format: Type|Name|Description|Points|other...
        var parts = SplitPreservePipes(line);
        if (parts.Length < 4)
            throw new FormatException("Invalid save line: " + line);

        var type = parts[0];
        var name = Unescape(parts[1]);
        var desc = Unescape(parts[2]);
        if (!int.TryParse(parts[3], out int points))
            throw new FormatException("Invalid points: " + parts[3]);

        switch (type)
        {
            case "Simple":
                if (parts.Length < 5 || !bool.TryParse(parts[4], out bool isComplete))
                    throw new FormatException("Invalid SimpleGoal line.");
                return new SimpleGoal(name, desc, points, isComplete);

            case "Eternal":
                // Eternal has no additional state
                return new EternalGoal(name, desc, points);

            case "Checklist":
                if (parts.Length < 7)
                    throw new FormatException("Invalid ChecklistGoal line.");
                if (!int.TryParse(parts[4], out int timesCompleted)) throw new FormatException();
                if (!int.TryParse(parts[5], out int target)) throw new FormatException();
                if (!int.TryParse(parts[6], out int bonus)) throw new FormatException();
                var cg = new ChecklistGoal(name, desc, points, target, bonus, timesCompleted);
                return cg;

            default:
                throw new NotSupportedException("Unknown goal type: " + type);
        }
    }

    // Helpers for escaping pipes and splitting lines safely
    protected static string Escape(string s) => s?.Replace("|", "&#124;") ?? "";
    protected static string Unescape(string s) => s?.Replace("&#124;", "|") ?? "";
    protected static string[] SplitPreservePipes(string line)
    {
        // Simple split, then unescape later; caller will unescape individual fields
        return line.Split('|');
    }
}

