namespace FinalProject
{
    class InventoryHistory : Inventory
    {
        private int _daysOut;
        private int _numTimesMediaOut;

        public InventoryHistory(Media media, string location) : base(media, location)
        {

        }
    }
}