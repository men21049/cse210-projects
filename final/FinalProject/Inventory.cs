namespace FinalProject
{
    class Inventory
    {
        List<Media> _media = new List<Media>();
        private string _location;
        private bool _isCheckOut;
        private DateTime _dateCheckout;
        private DateTime _dateReturn;
        FileManager _fileManagerInventory;

        public Inventory(Media media, string location)
        {
            _media.Add(media);
            _location = location;
        }

        public bool IsCheckout()
        {
            return _isCheckOut;
        }

        public string FindLoc(string mediaType, string title)
        {
            string ans = "";
            foreach (Media media in _media)
            {
                if (media.GetMediaType() == mediaType & media.GetTitle() == title)
                {
                    ans = _location;
                }
            }
            return ans;
        }

        public DateTime FindCheckOut(string mediaType, string title)
        {
            DateTime ans = DateTime.UnixEpoch;
            foreach (Media media in _media)
            {
                if (media.GetMediaType() == mediaType & media.GetTitle() == title)
                {
                    ans = _dateCheckout;
                }
            }
            return ans;
        }

        public DateTime FindReturn(string mediaType, string title)
        {
            DateTime ans = DateTime.UnixEpoch;
            foreach (Media media in _media)
            {
                if (media.GetMediaType() == mediaType & media.GetTitle() == title)
                {
                    ans = _dateReturn;
                }
            }
            return ans;
        }

        public DateTime GetCheckout()
        {
            return _dateCheckout;
        }
        public DateTime GetReturnDT()
        {
            return _dateReturn;
        }
        public string GetLocation()
        {
            return _location;
        }
        public bool ComparedTitle(string mediaType, string title)
        {
            bool ans = false;
            foreach (Media media in _media)
            {
                if (media.GetMediaType() == mediaType & media.GetTitle() == title)
                {
                    ans = true;
                }
            }
            return ans;
        }

        public List<Media> GetAllMedia()
        {
            return _media;
        }

        public void SetCheckout()
        {
            _isCheckOut = true;
            _dateCheckout = DateTime.Now;
        }

        public void SetReturn()
        {
            _dateReturn = DateTime.Now;
        }

    }
}