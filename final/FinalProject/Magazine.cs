using System.Diagnostics.CodeAnalysis;

namespace FinalProject
{
    class Magazine : Media
    {
        private int _numPages;
        private string _editorial;

        public Magazine(int numPages, string editorial, string mediaType, string title, string genre, string upc) : base(mediaType, title, genre, upc)
        {
            _numPages = numPages;
            _editorial = editorial;
        }

        public int GetNumPages()
        {
            return _numPages;
        }

        public string GetEditorial()
        {
            return _editorial;
        }
    }
}