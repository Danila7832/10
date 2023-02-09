using Newtonsoft.Json;
using _10laba.dto;

namespace _10laba
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveLoad.loadAll();

            ConsoleKey key;
            do
            {
                if (Auth.checkAuth())
                {
                    MainMenu.menu();
                }
                Console.Clear();
                Console.WriteLine("Для выхода нажмите escape, для продолжения нажмите любую клавишу");
                key = Console.ReadKey().Key;
                Console.Clear();

            } while (key != ConsoleKey.Escape);

            SaveLoad.saveAll();
        }

    }
}
    



        

        
    
