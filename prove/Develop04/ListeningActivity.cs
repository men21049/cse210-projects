class ListeningActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>(){"Who are people that you appreciate?"
                                                      ,"What are personal strengths of yours?"
                                                      ,"Who are people that you have helped this week?"
                                                      ,"When have you felt the Holy Ghost this month?"
                                                      ,"Who are some of your personal heroes?"};

    private List<string> _answers = new List<string>();
    private List<int> _randomPromptUsedIdx = new List<int>(4);
    public ListeningActivity(string name, string description) : base(name, description)
    {

    }

    public int GetAnswerCount()
    {
        _count = _answers.Count;
        return _count;
    }
    public void Run()
    {
        GetReady();
        Console.WriteLine("List as many responses you can to the following prompt:");
        GetRandomPrompt();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        SetListFromUser();
        DisplayEndingMessage();
    }

    public void GetRandomPrompt()
    {
        bool _rerun = true;
        string _randomPrompt = "";
        while (_rerun)
        {
            Random _rnd = new Random();
            int _randomNumber = _rnd.Next(0, 4);
            if (!_randomPromptUsedIdx.Contains(_randomNumber))
            {
                _randomPromptUsedIdx.Add(_randomNumber);
                _rerun = false;
                _randomPrompt = _prompts[_randomNumber];
            }
        }
        Console.WriteLine($"---{_randomPrompt} ---");
    }

    public void SetListFromUser()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write(">");
            string input = Console.ReadLine();
            _answers.Add(input);
            Thread.Sleep(1000);
        }

        Console.WriteLine($"You have listed {GetAnswerCount()} items");
    }
}
