class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>{"Think of a time when you stood up for someone else."
                                                     ,"Think of a time when you did something really difficult."
                                                     ,"Think of a time when you helped someone in need."
                                                     ,"Think of a time when you did something truly selfless."};
    private List<string> _questions = new List<string>{"Why was this experience meaningful to you?"
                                                      ,"Have you ever done anything like this before?"
                                                      ,"How did you get started?"
                                                      ,"How did you feel when it was complete?"
                                                      ,"What made this time different than other times when you were not as successful?"
                                                      ,"What is your favorite thing about this experience?"
                                                      ,"What could you learn from this experience that applies to other situations?"
                                                      ,"What did you learn about yourself through this experience?"
                                                      ,"How can you keep this experience in mind in the future?"};
    private List<int> _randomPromptUsedIdx = new List<int>(4);
    private List<int> _randomQuestionUsedIdx = new List<int>(9);

    public ReflectingActivity(string name, string description) : base(name, description)
    {

    }

    public void Run()
    {
        GetReady();
        DisplayPrompt();
        DisplayQuestions();
        DisplayEndingMessage();
    }
    public string GetRandomPrompt()
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
        return _randomPrompt;
    }

    public string GetRandomQuestion()
    {
        bool _rerun = true;
        string _randomQuestion = "";
        while (_rerun)
        {
            Random _rnd = new Random();
            int _randomNumber = _rnd.Next(0, 9);
            if (!_randomQuestionUsedIdx.Contains(_randomNumber))
            {
                _randomQuestionUsedIdx.Add(_randomNumber);
                _rerun = false;
                _randomQuestion = _questions[_randomNumber];
            }
        }
        return _randomQuestion;
    }

    public void DisplayPrompt()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt: ");
        Console.WriteLine();
        Console.WriteLine($"---{GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue");
        Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();
    }

    public void DisplayQuestions()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write($">{GetRandomQuestion()}");
            ShowSpinner(10);
            Console.WriteLine();
        }
    }
}