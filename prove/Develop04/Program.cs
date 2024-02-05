using System;

class Program
{
    static void Main(string[] args)
    {
        string answer = "0";
        BreathingActivity breathingActivity;
        ReflectingActivity reflectingActivity;
        ListeningActivity listeningActivity;
        while (answer != "4")
        {
            answer = MenuOptions();

            if (answer.Equals("1"))
            {
                breathingActivity = new BreathingActivity("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
                breathingActivity.DisplayStartingMessage();
                breathingActivity.SetDuration();
                breathingActivity.Run();
            }
            else if (answer.Equals("2"))
            {
                reflectingActivity = new ReflectingActivity("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
                reflectingActivity.DisplayStartingMessage();
                reflectingActivity.SetDuration();
                reflectingActivity.ShowSpinner(3);
                reflectingActivity.Run();
            }
            else if (answer.Equals("3"))
            {
                listeningActivity = new ListeningActivity("Listening", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
                listeningActivity.DisplayStartingMessage();
                listeningActivity.SetDuration();
                listeningActivity.ShowSpinner(3);
                listeningActivity.Run();
            }
            else
            {
                Environment.Exit(1);
            }
        }

    }

    public static string MenuOptions()
    {
        Console.WriteLine("Menu Options: ");
        Console.WriteLine("  1. Start Breathing activity");
        Console.WriteLine("  2. Start Reflecting activity");
        Console.WriteLine("  3. Start Listening activity");
        Console.WriteLine("  4. Quit");
        Console.Write("Select a choice from the menu: ");
        string _answer = Console.ReadLine();
        return _answer;
    }
}