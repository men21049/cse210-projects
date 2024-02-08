namespace Develop05
{
    class CheckListGoal : Goal
    {

        private int _amountCompleted;
        private int _target;
        private int _bonus;
        public CheckListGoal(string name, string description, string points) : base(name, description, points) { }

        public override void RecordEvent()
        {

        }

        public override bool IsComplete()
        {
            return false;
        }

        public override string GetDetailsString()
        {
            return base.GetDetailsString();
        }
        public override string GetStringRepresentation()
        {
            return base.GetStringRepresentation();
        }
    }
}