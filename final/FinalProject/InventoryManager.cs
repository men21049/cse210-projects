using System.Security.Cryptography.X509Certificates;

namespace FinalProject
{
    class InventoryManager
    {
        List<Inventory> _inventories = new List<Inventory>();
        List<Book> _books = new List<Book>();
        List<Video> _videos = new List<Video>();
        List<Magazine> _magazine = new List<Magazine>();

        private string _booksInv = "inventoryBooks.txt";
        private string _videosInv = "inventoryVideos.txt";
        private string _magazineInv = "inventoryMagazine.txt";
        private List<string> _animationStrings = new List<string>() { "|", "/", "-", "\\", "|", "/", "-", "\\" };
        public void Start()
        {
            string _answer = "0";
            while (_answer != "6")
            {
                DisplayWelcome();
                Console.WriteLine("Menu Options");
                Console.WriteLine("\t 1. See Library:");
                Console.WriteLine("\t 2. Checkout:");
                Console.WriteLine("\t 3. Return:");
                Console.WriteLine("\t 6. Quit");
                Console.Write("Select a choice from the menu:");
                _answer = Console.ReadLine();

                if (_answer == "1")
                {
                    SeeLibrary();
                }

            }

        }

        public void DisplayWelcome()
        {
            Console.WriteLine();
            string s = new string('*', 10);
            DisplayMessage(" Welcome to Library MS ");
            Console.WriteLine($"{s}{s}{s}{s}{s}");
        }

        public void DisplayMessage(string message)
        {

            string s = new string('*', 10);
            string _message = s + message + s;
            Console.WriteLine(_message);
        }

        public void SeeBooksLibrary()
        {
            Console.WriteLine();
            Console.WriteLine();
            DisplayMessage(" Books Inventory ");
            Console.WriteLine("{0,-10}|{1,20}|{2,15}|{3,9}|{4,46}|{5,10}|{6,12}|{7,4}|{8,12}|{9,12}", "Media", "Title", "Genre", "num Pages", "editorial", "coverType", "UPC", "Loc", "Date checkout", "Date return");
            Console.WriteLine();

            DateTime checkoutDT = DateTime.UnixEpoch;
            DateTime returnDT = DateTime.UnixEpoch;
            string loc = "";

            foreach (Book book in _books)
            {
                foreach (Inventory inv in _inventories)
                {
                    loc = inv.FindLoc(book.GetMediaType(), book.GetTitle());
                    checkoutDT = inv.FindCheckOut(book.GetMediaType(), book.GetTitle());
                    returnDT = inv.FindReturn(book.GetMediaType(), book.GetTitle());
                }

                Console.WriteLine("{0,-10}|{1,20}|{2,15}|{3,9}|{4,46}|{5,10}|{6,12}|{7,4}|{8,13}|{9,13}", book.GetMediaType(), book.GetTitle(), book.GetGenre(), book.GetNumPg(), book.GetEditorial(), book.GetCoverType(), book.GetUPC(), loc, checkoutDT, returnDT);
            }
        }

        public void LoadBookLib()
        {
            FileManager _fileManagerBooks = new FileManager(_booksInv);
            List<string> bookList = new List<string>(_fileManagerBooks.ReadFile());
            foreach (string line in bookList)
            {
                string[] row = line.Split("|");
                string mediaType = row[0].Trim();
                string title = row[1].Trim();
                string genre = row[2].Trim();
                int numPages = int.Parse(row[3]);
                string editorial = row[4].Trim();
                string coverType = row[5].Trim();
                string upc = row[6].Trim();
                string location = row[7].Trim();
                string dateCheckout = row[8].Trim();
                string dateReturn = row[9].Trim();

                Book book = new Book(numPages, editorial, coverType, mediaType, title, genre, upc);
                Inventory bInv = new Inventory(book, location);

                if (_inventories.Count() == 0)
                {
                    _inventories.Add(bInv);
                    _books.Add(book);
                }

                foreach (Inventory inv in _inventories)
                {

                    if (!inv.ComparedTitle(mediaType, title))
                    {
                        _inventories.Add(bInv);
                        _books.Add(book);
                    }
                }
            }

        }
        public void SeeVideoLibrary()
        {
            FileManager _fileManagerVideos = new FileManager(_videosInv);
            List<string> videoList = new List<string>(_fileManagerVideos.ReadFile());

            Console.WriteLine();
            Console.WriteLine();
            DisplayMessage(" Video Inventory ");
            Console.WriteLine("{0,-10}|{1,30}|{2,15}|{3,9}|{4,12}|{5,4}|{6,12}|{7,12}", "Media", "Title", "Genre", "Video Length", "UPC", "Loc", "Date checkout", "Date return");
            Console.WriteLine();

            DateTime checkoutDT = DateTime.UnixEpoch;
            DateTime returnDT = DateTime.UnixEpoch;
            string loc = "";

            foreach (Video video in _videos)
            {
                foreach (Inventory inv in _inventories)
                {
                    loc = inv.FindLoc(video.GetMediaType(), video.GetTitle());
                    checkoutDT = inv.FindCheckOut(video.GetMediaType(), video.GetTitle());
                    returnDT = inv.FindReturn(video.GetMediaType(), video.GetTitle());
                }
                Console.WriteLine("{0,-10}|{1,30}|{2,15}|{3,9}|{4,12}|{5,4}|{6,12}|{7,12}", video.GetMediaType(), video.GetTitle(), video.GetGenre(), video.GetVideoLen(), video.GetUPC(), loc, checkoutDT, returnDT);
            }
        }

        public void LoadVideos()
        {
            FileManager _fileManagerVideos = new FileManager(_videosInv);
            List<string> videoList = new List<string>(_fileManagerVideos.ReadFile());
            foreach (string line in videoList)
            {

                string[] row = line.Split("|");
                string mediaType = row[0];
                string title = row[1];
                string genre = row[2];
                string videoLength = row[3];
                string upc = row[4];
                string location = row[5];
                string dateCheckout = row[6];
                string dateReturn = row[7];


                Video video = new Video(videoLength, mediaType, title, genre, upc);
                Inventory vInv = new Inventory(video, location);

                if (_inventories.Count() == 0)
                {
                    _inventories.Add(vInv);
                    _videos.Add(video);
                }

                foreach (Inventory inv in _inventories)
                {
                    if (!inv.ComparedTitle(mediaType, title))
                    {
                        _inventories.Add(vInv);
                        _videos.Add(video);
                    }
                }
            }

        }
        public void SeeMagazineLibrary()
        {
            Console.WriteLine();
            Console.WriteLine();
            DisplayMessage(" Magazine Inventory ");
            Console.WriteLine("{0,-10}|{1,30}|{2,15}|{3,20}|{4,9}|{5,12}|{6,4}|{7,12}|{8,12}", "Media", "Title", "Genre", "Editorial", "Num Pages", "UPC", "Loc", "Date checkout", "Date return");

            Console.WriteLine();

            DateTime checkoutDT = DateTime.UnixEpoch;
            DateTime returnDT = DateTime.UnixEpoch;
            string loc = "";

            foreach (Magazine magazine in _magazine)
            {
                foreach (Inventory inv in _inventories)
                {
                    loc = inv.FindLoc(magazine.GetMediaType(), magazine.GetTitle());
                    checkoutDT = inv.FindCheckOut(magazine.GetMediaType(), magazine.GetTitle());
                    returnDT = inv.FindReturn(magazine.GetMediaType(), magazine.GetTitle());
                }

                Console.WriteLine("{0,-10}|{1,30}|{2,15}|{3,20}|{4,9}|{5,12}|{6,4}|{7,12}|{8,12}", magazine.GetMediaType(), magazine.GetTitle(), magazine.GetGenre(), magazine.GetEditorial(), magazine.GetNumPages(), magazine.GetUPC(), loc, checkoutDT, returnDT);
            }
        }

        public void LoadMagazine()
        {
            FileManager _fileManagerMagazine = new FileManager(_magazineInv);
            List<string> magazineList = new List<string>(_fileManagerMagazine.ReadFile());

            foreach (string line in magazineList)
            {
                string[] row = line.Split("|");
                string mediaType = row[0];
                string title = row[1];
                string genre = row[2];
                string editorial = row[3];
                int numPages = int.Parse(row[4]);
                string upc = row[5];
                string location = row[6];
                string dateCheckout = row[7];
                string dateReturn = row[8];


                Magazine magazine = new Magazine(numPages, editorial, mediaType, title, genre, upc);
                Inventory mInv = new Inventory(magazine, location);
                foreach (Inventory inv in _inventories)
                {
                    if (!inv.ComparedTitle(mediaType, title))
                    {
                        _inventories.Add(mInv);
                        _magazine.Add(magazine);
                    }
                }
            }
        }

        public void LoadAllInv()
        {
            LoadBookLib();
            LoadVideos();
            LoadMagazine();
        }
        public void SeeLibrary()
        {
            LoadAllInv();
            SeeBooksLibrary();
            SeeVideoLibrary();
            SeeMagazineLibrary();
            ShowSpinner(5);
            DisplayCheckoutReturnMenu();
            ShowSpinner(5);
        }

        public void ShowSpinner(int seconds)
        {
            foreach (string s in _animationStrings)
            {
                Console.Write(s);
                Thread.Sleep(500);
                Console.Write("\b \b");
            }
        }

        public void DisplayCheckoutReturnMenu()
        {

            Console.WriteLine();
            Console.WriteLine("Would you like to checkout or return a book? ");
            Console.Write("1 for check out 2 for return or 0 to exit the menu and return to the previous menu: ");
            string checkoutReturnanswer = Console.ReadLine();

            if (checkoutReturnanswer == "1")
            {
                Checkout();
            }
            else if (checkoutReturnanswer == "2")
            {
                Return();
            }

        }

        public void Checkout()
        {
            LoadAllInv();
            Console.WriteLine("Please pick from the below menu: ");
            Console.WriteLine("Select the media you would like to checkout: ");
            Console.WriteLine("1.- Book (Press 1) ");
            Console.WriteLine("2.- Video (Press 2) ");
            Console.WriteLine("3.- Magazine (Press 3) ");
            string answer = Console.ReadLine();
            Console.WriteLine("Please enter the title: ");
            string title = Console.ReadLine();

            if (answer == "1")
            {
                FileManager _fileManagerBooks = new FileManager(_booksInv);
                foreach (Inventory inventory in _inventories)
                {
                    if (inventory.ComparedTitle("Book", title))
                    {
                        inventory.SetCheckout();
                    }
                    DateTime checkoutDT = inventory.GetCheckout();
                    DateTime returnDT = inventory.GetReturnDT();
                    string loc = inventory.GetLocation();
                    foreach (Book book in _books)
                    {
                        string lineToSave = string.Format("{0,-10}|{1,20}|{2,15}|{3,9}|{4,46}|{5,10}|{6,12}|{7,4}|{8,13}|{9,13}", book.GetMediaType(), book.GetTitle(), book.GetGenre(), book.GetNumPg(), book.GetEditorial(), book.GetCoverType(), book.GetUPC(), loc, checkoutDT, returnDT);
                        _fileManagerBooks.SaveFile(lineToSave);
                    }
                }
            }
            else if (answer == "2")
            {
                FileManager _fileManagerBooks = new FileManager(_videosInv);
                SeeVideoLibrary();
                foreach (Inventory inventory in _inventories)
                {
                    if (inventory.ComparedTitle("Video", title))
                    {
                        inventory.SetCheckout();
                    }
                    DateTime checkoutDT = inventory.GetCheckout();
                    DateTime returnDT = inventory.GetReturnDT();
                    string loc = inventory.GetLocation();
                    foreach (Video video in _videos)
                    {
                        string lineToSave = string.Format("{0,-10}|{1,30}|{2,15}|{3,9}|{4,12}|{5,4}|{6,12}|{7,12}", video.GetMediaType(), video.GetTitle(), video.GetGenre(), video.GetVideoLen(), video.GetUPC(), loc, checkoutDT, returnDT);
                        _fileManagerBooks.SaveFile(lineToSave);
                    }
                }
            }
            else if (answer == "3")
            {
                FileManager _fileManagerBooks = new FileManager(_magazineInv);
                SeeMagazineLibrary();
                foreach (Inventory inventory in _inventories)
                {
                    if (inventory.ComparedTitle("Magazine", title))
                    {
                        inventory.SetCheckout();
                    }
                    DateTime checkoutDT = inventory.GetCheckout();
                    DateTime returnDT = inventory.GetReturnDT();
                    string loc = inventory.GetLocation();
                    foreach (Magazine magazine in _magazine)
                    {
                        string lineToSave = string.Format("{0,-10}|{1,30}|{2,15}|{3,20}|{4,9}|{5,12}|{6,4}|{7,12}|{8,12}", magazine.GetMediaType(), magazine.GetTitle(), magazine.GetGenre(), magazine.GetEditorial(), magazine.GetNumPages(), magazine.GetUPC(), loc, checkoutDT, returnDT);
                        _fileManagerBooks.SaveFile(lineToSave);
                    }
                }
            }

        }
        public void Return()
        {
            LoadAllInv();
            Console.WriteLine("Please pick from the below menu: ");
            Console.WriteLine("Select the media you would like to return: ");
            Console.WriteLine("1.- Book (Press 1) ");
            Console.WriteLine("2.- Video (Press 2) ");
            Console.WriteLine("3.- Magazine (Press 3) ");
            string answer = Console.ReadLine();
            Console.WriteLine("Please enter the title: ");
            string title = Console.ReadLine();

            if (answer == "1")
            {
                FileManager _fileManagerBooks = new FileManager(_booksInv);
                SeeBooksLibrary();
                foreach (Inventory inventory in _inventories)
                {
                    if (inventory.ComparedTitle("Book", title))
                    {
                        inventory.SetReturn();
                    }
                    DateTime checkoutDT = inventory.GetCheckout();
                    DateTime returnDT = inventory.GetReturnDT();
                    string loc = inventory.GetLocation();
                    foreach (Book book in _books)
                    {
                        string lineToSave = string.Format("{0,-10}|{1,20}|{2,15}|{3,9}|{4,46}|{5,10}|{6,12}|{7,4}|{8,13}|{9,13}", book.GetMediaType(), book.GetTitle(), book.GetGenre(), book.GetNumPg(), book.GetEditorial(), book.GetCoverType(), book.GetUPC(), loc, checkoutDT, returnDT);
                        _fileManagerBooks.SaveFile(lineToSave);
                    }
                }
            }
            else if (answer == "2")
            {
                FileManager _fileManagerBooks = new FileManager(_videosInv);
                SeeVideoLibrary();
                foreach (Inventory inventory in _inventories)
                {
                    if (inventory.ComparedTitle("Video", title))
                    {
                        inventory.SetReturn();
                    }
                    DateTime checkoutDT = inventory.GetCheckout();
                    DateTime returnDT = inventory.GetReturnDT();
                    string loc = inventory.GetLocation();
                    foreach (Video video in _videos)
                    {
                        string lineToSave = string.Format("{0,-10}|{1,30}|{2,15}|{3,9}|{4,12}|{5,4}|{6,12}|{7,12}", video.GetMediaType(), video.GetTitle(), video.GetGenre(), video.GetVideoLen(), video.GetUPC(), loc, checkoutDT, returnDT);
                        _fileManagerBooks.SaveFile(lineToSave);
                    }
                }
            }
            else if (answer == "3")
            {
                FileManager _fileManagerBooks = new FileManager(_magazineInv);
                SeeMagazineLibrary();
                foreach (Inventory inventory in _inventories)
                {
                    if (inventory.ComparedTitle("Magazine", title))
                    {
                        inventory.SetReturn();
                    }
                    DateTime checkoutDT = inventory.GetCheckout();
                    DateTime returnDT = inventory.GetReturnDT();
                    string loc = inventory.GetLocation();
                    foreach (Magazine magazine in _magazine)
                    {
                        string lineToSave = string.Format("{0,-10}|{1,30}|{2,15}|{3,20}|{4,9}|{5,12}|{6,4}|{7,12}|{8,12}", magazine.GetMediaType(), magazine.GetTitle(), magazine.GetGenre(), magazine.GetEditorial(), magazine.GetNumPages(), magazine.GetUPC(), loc, checkoutDT, returnDT);
                        _fileManagerBooks.SaveFile(lineToSave);
                    }
                }
            }

        }
    }
}
