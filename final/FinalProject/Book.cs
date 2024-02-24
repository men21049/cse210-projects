namespace FinalProject
{
    class Book : Media
    {
        private int _numPages;
        private string _editorial;
        private string _coverType;

        public Book(int numPages, string editorial, string coverType, string mediaType, string title, string genre, string upc) : base(mediaType, title, genre, upc)
        {
            _numPages = numPages;
            _editorial = editorial;
            _coverType = coverType;
        }
        public int GetNumPg()
        {
            return _numPages;
        }

        public string GetEditorial()
        {
            return _editorial;
        }
        public string GetCoverType()
        {
            return _coverType;
        }

    }

}