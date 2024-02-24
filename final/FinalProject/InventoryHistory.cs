namespace FinalProject
{
    class InventoryHistory : Inventory
    {
        private int _daysOut;
        private int _numTimesMediaOut;

        public InventoryHistory(Media media, string location) : base(media, location)
        {

        }

        public int DaysOut(DateTime dt)
        {
            DateTime now = DateTime.Now;
            TimeSpan diffResult = now.Subtract(dt);
            return diffResult.Days;
        }
    }
}