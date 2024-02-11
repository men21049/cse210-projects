namespace Develop05
{
    abstract class Goal
    {
        private string _shortname;
        private string _description;
        private int _points;

        public Goal(string shortname, string description, int points)
        {
            _shortname = shortname;
            _description = description;
            _points = points;
        }

        public string GetShortName
        {
            get
            {
                return this._shortname;
            }

        }

        public int GetPoints
        {
            get
            {
                return this._points;
            }
        }

        public string GetDescription
        {
            get
            {
                return this._description;
            }
        }
        public abstract void RecordEvent();
        public abstract bool IsComplete();
        public virtual string GetDetailsString()
        {
            if (IsComplete())
            {
                return $"[x] {GetShortName} : {GetDescription}";
            }
            else
            {
                return $"[] {GetShortName} : {GetDescription}";
            }
        }

        public abstract int GetBonus();
        public abstract string GetStringRepresentation();

    }
}