namespace Develop05
{
    class Goal
    {
        private string _shortname;
        private string _description;
        private string _points;

        public Goal(string shortname, string description, string points)
        {
            _shortname = shortname;
            _description = description;
            _points = points;
        }

        public virtual void RecordEvent() { }
        public virtual bool IsComplete()
        {
            return false;
        }
        public virtual string GetDetailsString()
        {
            return "hola";
        }
        public virtual string GetStringRepresentation()
        {
            return "hola2";
        }


    }
}