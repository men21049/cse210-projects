namespace FinalProject
{
    class FileManager
    {
        private string _filename;

        public FileManager(string filename)
        {
            Console.WriteLine("What is the filename for the goal file? ");
            _filename = Console.ReadLine();
        }

        public void SaveFile(string line)
        {
            using (StreamWriter outputFile = new StreamWriter(_filename, append: false))
            {
                outputFile.WriteLine(line);

            }

        }
    }
}