internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        Console.WriteLine("what is your grade percent?");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);


        string letter = "";

        if (percent >= 90)


        {
            letter = "A";
        }


        else if (percent >= 80)

        {

            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";

        }
        else if (percent >= 60)

        {
            letter = "D";

        }
        else

        {
            letter = "F";

        }
        Console.WriteLine($"your grade is: {letter}");

        if (percent >= 70)

        {
            Console.Write("you have passed!");
        }

        else
        {
            Console.WriteLine("Better luck next time");

        }

    }
}