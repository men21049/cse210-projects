namespace Learning05
{
    class Shape
    {
        private string _color;
        private double _area = 0.0;

        public Shape(string color)
        {
            _color = color;
        }
        public string GetColor()
        {
            return _color;
        }

        public virtual double GetArea()
        {
            return _area;
        }
    }
}
