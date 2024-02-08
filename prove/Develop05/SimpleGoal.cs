namespace Develop05
{
    class SimpleGoal : Goal
    {
        private bool _iscomplete;

        public SimpleGoal(string name, string description, string points) : base(name, description, points)
        {

        }

        public override void RecordEvent()
        {

        }

        public override bool IsComplete()
        {
            return _iscomplete;
        }

        public override string GetStringRepresentation()
        {
            return base.GetStringRepresentation();
        }
    }

}