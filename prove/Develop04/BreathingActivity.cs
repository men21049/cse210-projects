class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {

    }

    public void Run()
    {
        GetReady();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("Breath in ...");
            ShowCountDown(4);
            Console.WriteLine();
            Console.Write("Now breath out...");
            ShowCountDown(6);
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(1000);
        }
        DisplayEndingMessage();
    }
}