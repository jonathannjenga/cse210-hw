class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
    }
}
public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
    public void Display()
    {
        Console.WriteLine($"    {CommenterName}: {Text}");
    }
}
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> Comments = new List<Comment>();

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine($"Title:  {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");

        foreach (Comment comment in Comments)
        {
            comment.Display();
        }
        Console.WriteLine();
    }
}
public class Program;
{
    public static void Main()
    {
List<Video> videos = new List<Video>();
Video video1 = new Video("Exploring Kenya's Coffee Estates", "Opulent Media", 420);
        video1.AddComment(new Comment("Alice", "Amazing footage of the coffee process!"));
        video1.AddComment(new Comment("Brian", "Would love to visit Kenya someday."));
        video1.AddComment(new Comment("Cynthia", "This was really educational."));
        videos.Add(video1);
        Video video2 = new Video("How to Roast Coffee Beans", "BaristaPro", 315);
        video2.AddComment(new Comment("Derrick", "Perfect guide for beginners."));
        video2.AddComment(new Comment("Eva", "Now I can make my own roast!"));
        video2.AddComment(new Comment("Frank", "The sound of roasting is so relaxing."));
        videos.Add(video2);
        Video video3 = new Video("Sustainable Coffee Farming in Africa", "Green Earth Channel", 500);
        video3.AddComment(new Comment("George", "We need more sustainable farming like this."));
        video3.AddComment(new Comment("Hannah", "Brilliant work, thanks for sharing!"));
        video3.AddComment(new Comment("Ivy", "Loved the visuals and message."));
        videos.Add(video3);
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
      Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("Program execution complete. Press any key to exit...");
        Console.ReadKey();
    }
}
