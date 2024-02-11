namespace Develop05
{
    class CheckListGoal : Goal
    {

        private int _amountCompleted = 0;
        private int _target;
        private int _bonus;
        public CheckListGoal(string name, string description, int points, int target, int bonus, int amountCompleted) : base(name, description, points)
        {
            _target = target;
            _bonus = bonus;
            _amountCompleted = amountCompleted;
        }

        public override void RecordEvent()
        {
            _amountCompleted += 1;
        }

        public override bool IsComplete()
        {
            if (_target == _amountCompleted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetBonus()
        {
            return _bonus;
        }
        public override string GetDetailsString()
        {
            if (IsComplete())
            {
                return $"[x] {GetShortName} : {GetDescription} -- Currently completed: {_amountCompleted}/{_target}";
            }
            else
            {
                return $"[] {GetShortName} : {GetDescription} -- Currently completed: {_amountCompleted}/{_target}";
            }

        }
        public override string GetStringRepresentation()
        {
            return $"CheckList Goal|{GetShortName}|{GetDescription}|{GetPoints}|{_target}|{_bonus}|{_amountCompleted}";
        }
    }
}