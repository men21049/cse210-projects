namespace Develop05
{
    class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points) : base(name, description, points)
        { }
        public override void RecordEvent()
        {

        }

        public override bool IsComplete()
        {
            return false;
        }
        public override int GetBonus()
        {
            return 0;
        }
        public override string GetStringRepresentation()
        {
            return $"Eternal Goal|{GetShortName}|{GetDescription}|{GetPoints}";
        }
    }
}