using System;
namespace _10laba
{
    public static class EditText
    {
        public static string edit(int leftPosition,int topPosition, string text)
        {
            bool exit = false;
            ConsoleKeyInfo key;
            Console.SetCursorPosition(leftPosition + text.Length, topPosition);
            do
            {

                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        exit = true;
                        break;
                    case ConsoleKey.Escape:
                        exit = true;
                        text = "";
                        break;
                    case ConsoleKey.Backspace:
                        if (text.Length > 0)
                        {
                            text = text.Substring(0, text.Length - 1);
                            Console.SetCursorPosition(leftPosition + text.Length + 1, topPosition);
                            Console.Write("\b \b ");
                            Console.SetCursorPosition(leftPosition + text.Length, topPosition);
                        }
                        else
                            Console.SetCursorPosition(leftPosition, topPosition);
                        break;
                    default:
                        Console.SetCursorPosition(leftPosition + text.Length, topPosition);
                        Console.Write(key.KeyChar);
                        text += key.KeyChar;
                        break;
                }
            } while (!exit);

            return text;
        }
    }
}

