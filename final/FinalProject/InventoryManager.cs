namespace FinalProject
{
    class InventoryManager
    {
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
                Console.WriteLine("\t 4. See reports:");
                Console.WriteLine("\t 6. Quit");
                Console.Write("Select a choice from the menu:");
                _answer = Console.ReadLine();

            }

        }

        public void DisplayWelcome()
        {
            string str = " Welcome to Library MS ";
            string s = new string('*', 10);
            string welcomeMsg = s + str + s;
            Console.Clear();
            Console.WriteLine($"{s}{s}{s}{s}{s}");
            Console.WriteLine($"   {welcomeMsg}");
            Console.WriteLine($"{s}{s}{s}{s}{s}");
        }
    }
}