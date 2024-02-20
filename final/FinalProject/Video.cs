namespace FinalProject
{
    class Video : Media
    {
        private string _videoLength;
        private List<string> actors = new List<string>();

        public Video(string videoLength, string mediaType, string title, string genre, string upc) : base(mediaType, title, genre, upc)
        {
            _videoLength = videoLength;
        }
    }
}