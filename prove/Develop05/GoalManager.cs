using System.Security.Cryptography.X509Certificates;

namespace Develop05
{
    class GoalManager
    {
        List<Goal> _goals = new List<Goal>();
        private int _score = 0;
        List<string> _goalsListOrder = new List<string>();

        public GoalManager()
        {
        }

        public void Start()
        {
            string _answer = "0";
            while (_answer != "6")
            {
                DisplayPlayerInfo();
                Console.WriteLine("Menu Options");
                Console.WriteLine("\t 1. Create New Goal:");
                Console.WriteLine("\t 2. List Goals:");
                Console.WriteLine("\t 3. Save Goals:");
                Console.WriteLine("\t 4. Load Goals:");
                Console.WriteLine("\t 5. Record Event:");
                Console.WriteLine("\t 6. Quit");
                Console.Write("Select a choice from the menu:");
                _answer = Console.ReadLine();

                if (_answer == "1")
                {
                    CreateGoal();
                }
                else if (_answer == "2")
                {
                    ListGoalDetails();
                }
                else if (_answer == "3")
                {
                    SaveGoals();
                }
                else if (_answer == "4")
                {
                    LoadGoals();
                }
                else if (_answer == "5")
                {
                    RecordEvent();
                }
            }
        }

        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"You have {_score} points");
            Console.WriteLine("");
        }

        public void ListGoalNames()
        {
            foreach (var goal in _goals.Select((value, i) => new { i, value }))
            {
                var value = goal.value.GetShortName;
                var index = goal.i;
                Console.WriteLine($"\t {index + 1}. {value}");
            }
        }

        public void ListGoalDetails()
        {
            foreach (Goal goal in _goals)
            {
                Console.WriteLine(goal.GetDetailsString());
            }
        }

        public void CreateGoal()
        {
            Console.WriteLine("The type of Goals are: ");
            Console.WriteLine("\t 1. Simple Goal");
            Console.WriteLine("\t 2. Eternal Goal");
            Console.WriteLine("\t 3. Checklist Goal");
            Console.Write("What type of Goal would you like to create? ");
            string _answerGoal = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("What is the name of the Goal? ");
            string _goalName = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("What is a short description of it? ");
            string _goalDesc = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("How many points are associated with this Goal? ");
            int _goalPoints = int.Parse(Console.ReadLine());

            if (_answerGoal == "1")
            {
                SimpleGoal simple = new SimpleGoal(_goalName, _goalDesc, _goalPoints);
                _goals.Add(simple);
                _goalsListOrder.Add("Simple Goal");
            }
            else if (_answerGoal == "2")
            {
                EternalGoal eternalGoal = new EternalGoal(_goalName, _goalDesc, _goalPoints);
                _goals.Add(eternalGoal);
                _goalsListOrder.Add("Eternal Goal");
            }
            else if (_answerGoal == "3")
            {
                Console.WriteLine("");
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int _target = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int _bonus = int.Parse(Console.ReadLine());
                CheckListGoal checkListGoal = new CheckListGoal(_goalName, _goalDesc, _goalPoints, _target, _bonus, 0);
                _goals.Add(checkListGoal);
                _goalsListOrder.Add("CheckList Goal");

            }
        }

        public void RecordEvent()
        {
            ListGoalNames();
            Console.WriteLine("Which goal did you accomplish? ");
            int _goalAcc = int.Parse(Console.ReadLine());

            for (int i = 1; i <= GetGoalListLenght(); i++)
            {

                if (i == _goalAcc)
                {
                    _goals[i - 1].RecordEvent();
                    if (_goals[i - 1].IsComplete())
                    {
                        _score += _goals[i - 1].GetPoints + _goals[i - 1].GetBonus();
                    }
                    else
                    {
                        _score += _goals[i - 1].GetPoints;
                    }
                    break;
                }
            }

        }

        public void SaveGoals()
        {
            string _filename;
            Console.WriteLine("What is the filename for the goal file? ");
            _filename = Console.ReadLine();
            using (StreamWriter outputFile = new StreamWriter(_filename, append: false))
            {
                outputFile.WriteLine(_score);
                foreach (var goal in _goals)
                {
                    outputFile.WriteLine($"{goal.GetStringRepresentation()}");
                }
            }
        }

        public void LoadGoals()
        {
            string _filename;
            Console.WriteLine("What is the filename for the Goal file? ");
            _filename = Console.ReadLine();
            string[] lines = System.IO.File.ReadAllLines(_filename);

            foreach (var line in lines)
            {
                if (line == lines[0])
                {
                    _score = int.Parse(line);
                }
                else
                {
                    string[] row = line.Split("|");
                    string goalName = row[1];
                    string goalDescription = row[2];
                    int goalPoints = int.Parse(row[3]);
                    _goalsListOrder.Add($"{row[0]}");

                    if (row[0] == "Simple Goal")
                    {
                        SimpleGoal simple = new SimpleGoal(goalName, goalDescription, goalPoints);
                        _goals.Add(simple);
                        if (bool.Parse(row[4]))
                        {
                            simple.RecordEvent();
                        }
                    }
                    else if (row[0] == "Eternal Goal")
                    {
                        EternalGoal eternalGoal = new EternalGoal(goalName, goalDescription, goalPoints);
                        _goals.Add(eternalGoal);
                    }
                    else if (row[0] == "CheckList Goal")
                    {
                        CheckListGoal checkListGoal = new CheckListGoal(goalName, goalDescription, goalPoints, int.Parse(row[4]), int.Parse(row[5]), int.Parse(row[6]));
                        _goals.Add(checkListGoal);
                    }

                }
            }
        }

        public int GetGoalListLenght()
        {
            return _goals.Count;
        }


    }

}
