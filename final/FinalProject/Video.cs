namespace FinalProject
{
    class Video : Media
    {
        private string _videoLength;
        private List<string> _actors = new List<string>();

        public Video(string videoLength, string mediaType, string title, string genre, string upc) : base(mediaType, title, genre, upc)
        {
            _videoLength = videoLength;
        }

        public string GetVideoLen()
        {
            return _videoLength;
        }
        public void SetActors(string actor)
        {
            _actors.Add(actor);
        }

        public void ListActors()
        {
            foreach (string actor in _actors)
            {
                Console.Write("{actor} ;");
            }
        }
    }
}