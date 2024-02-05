class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    private List<string> _animationStrings = new List<string>() { "|", "/", "-", "\\", "|", "/", "-", "\\" };

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void SetDuration()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

    }

    public int GetDuration()
    {
        return _duration;
    }
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to {_name} activity.");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"{_description}");
        Console.WriteLine();
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well Done!");
        Console.WriteLine($"You have completed another {GetDuration()} seconds of the Breathing Activity");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        foreach (string s in _animationStrings)
        {
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b \b");
        }
    }

    public void GetReady()
    {
        Console.WriteLine("Get Ready ...");
        ShowSpinner(3);
        Console.Write("\b \b");
        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int i = seconds;
        while (DateTime.Now < endTime)
        {
            Console.Write($"{i}");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            i--;
        }
    }
}
