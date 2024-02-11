namespace Develop05
{
    class SimpleGoal : Goal
    {
        private bool _iscomplete;

        public SimpleGoal(string name, string description, int points) : base(name, description, points)
        {

        }

        public override void RecordEvent()
        {
            _iscomplete = true;
        }
        public override int GetBonus()
        {
            return 0;
        }
        public override bool IsComplete()
        {
            return _iscomplete;
        }

        public override string GetStringRepresentation()
        {
            return $"Simple Goal|{GetShortName}|{GetDescription}|{GetPoints}|{_iscomplete}";
        }
    }

}