namespace FinalProject
{
    class Media
    {
        private string _mediaType;
        private string _title;
        private string _genre;
        private string _upc;

        public Media(string mediaType, string title, string genre, string upc)
        {
            _mediaType = mediaType;
            _title = title;
            _genre = genre;
            _upc = upc;
        }

        public string GetTitle()
        {
            return _title;
        }
        public string GetGenre()
        {
            return _genre;
        }
        public string GetMediaType()
        {
            return _mediaType;
        }

        public string GetUPC()
        {
            return _upc;
        }
        public bool CompareGenre(string genre)
        {
            return _genre == genre;
        }
    }
}