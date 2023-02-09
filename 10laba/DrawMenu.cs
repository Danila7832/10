using System;
namespace _10laba
{
    public static class DrawMenu
    {
        public static void draw(String[] menu, int leftPosition, int topPosition)
        {
            List<string> fields = new List<string>();
            foreach (String str in menu) {
                fields.Add("");
            }
            DrawMenu.menu(fields.ToArray(), menu, topPosition, leftPosition);
        }

        public static void emptyMenu(String[] menu, int leftPosition, int topPosition)
        {
            List<string> fields = new List<string>();
            foreach (String str in menu)
            {
                fields.Add("");
            }
            DrawMenu.menu(menu, fields.ToArray(), topPosition, leftPosition);
        }

        public static void clear(String[] menu, int leftPosition, int topPosition)
        {
            for (int i = 0; i < menu.Length; i++)
            {
                for (int j = 0; j < menu[i].Length; j++)
                Console.SetCursorPosition(leftPosition + j, topPosition + i);
                Console.Write(" ");
            }
        }

        public static void drawData(String[] menu, int[] sizes, List<String[]> data) {

            int leftPosition = 2;

            for(int i = 0; i < menu.Length; i++) {
                Console.SetCursorPosition(leftPosition, 2);
                Console.Write(menu[i]);
                leftPosition += sizes[i];
            }

            
            int topPosition = 3;
            for (int i = 0; i < data.Count; i++) {
                leftPosition = 2;
                for (int j = 0; j < data[i].Length; j++ ) {
                    Console.SetCursorPosition(leftPosition, topPosition + i);
                    Console.Write(data[i][j]);
                    leftPosition += sizes[j];
                }
                
            }
        }

        public static void clearData(int dataCount, int leftPosition, int rightPosition, int topPosition) {
            for (int i = 0; i < dataCount; i++) {
                for (int j = leftPosition; j < rightPosition; j++) {
                    Console.SetCursorPosition(j, topPosition + i);
                    Console.Write("\b \b");
                }
            }
        }

        public static int arrowMenu(int leftPosition, int topPosition, int menuCount, int startPosition) {
            bool enter = false;
            ConsoleKey key;
            int currentPosition = topPosition + startPosition;

            do
            {
                Console.SetCursorPosition(leftPosition, currentPosition);
                Console.WriteLine("->");

                
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (currentPosition - 1 >= topPosition)
                        {
                            Console.SetCursorPosition(leftPosition, currentPosition);
                            Console.WriteLine("  ");
                            currentPosition--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentPosition + 1 <= menuCount + topPosition - 1)
                        {
                            Console.SetCursorPosition(leftPosition, currentPosition);
                            Console.WriteLine("  ");
                            currentPosition++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        enter = true;
                        break;
                }
            } while (key != ConsoleKey.Escape && !enter);

            //Console.SetCursorPosition(leftPosition, currentPosition);
            //Console.Write("  ");

            if (!enter)
                currentPosition = -1;
           return currentPosition;
        }

        public static int arrowNavigation(int startPosition, int menuCount, int topPosition) {
            Console.SetCursorPosition(110, 20);
            Console.Write("Вы в списке данных");
            startPosition = DrawMenu.arrowMenu(0, topPosition, menuCount, startPosition);
            Console.SetCursorPosition(110, 20);
            Console.Write("                  ");

            return startPosition;
        }

        public static void menu(String[] fields, String[] data, int topPosition, int leftPosition)
        {
            for(int i = 0; i < fields.Length; i++)
            {
                Console.SetCursorPosition(leftPosition, topPosition + i);
                Console.Write(fields[i] + data[i]);
            }   
        }


    }
}

