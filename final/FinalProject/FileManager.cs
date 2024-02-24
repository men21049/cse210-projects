namespace FinalProject
{
    using System.IO;
    class FileManager
    {
        private string _filename;
        private List<string> _invList = new List<string>();

        public FileManager(string filename)
        {
            _filename = filename;
        }

        public void SaveFile(string line)
        {
            using (StreamWriter outputFile = new StreamWriter(_filename, append: false))
            {
                outputFile.WriteLine(line);
            }
        }

        public List<string> ReadFile()
        {
            string[] lines = System.IO.File.ReadAllLines(this._filename);
            foreach (var line in lines)
            {
                _invList.Add(line);
            }
            return _invList;
        }
    }
}
