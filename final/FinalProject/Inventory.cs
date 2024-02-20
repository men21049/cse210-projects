namespace FinalProject
{
    class Inventory
    {
        List<Media> _media = new List<Media>();
        private string _location;
        private bool _isCheckOut;
        private DateTime _dateCheckout;
        private DateTime _dateReturn;

        public Inventory(Media media, string location)
        {
            _media.Add(media);
            _location = _location;
        }

        public bool isCheckout()
        {
            return _isCheckOut;
        }

        public void SetCheckout()
        {
            _dateCheckout = new DateTime();
        }

        public void SetReturn()
        {
            _dateReturn = new DateTime();
        }
    }
}