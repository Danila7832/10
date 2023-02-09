using System;
using _10laba.dto;

namespace _10laba
{
    public static class Auth
    {
        private static int id;

        public static bool checkAuth()
        {
            List<Login> logins = SaveLoad.Logins;
            int leftPosition = 2;
            int topPosition = 0;

            String[] menu = { "Логин:", "Пароль:", "Авторизоваться" };

            DrawMenu.draw(menu, leftPosition, topPosition);

            bool sucsess = false;
            bool escape = false;
            leftPosition = 0;
            int startPosition = 0;
            string login = "";
            string password = "";
            do
            {
                startPosition = DrawMenu.arrowMenu(0, 0, 3, startPosition);
                switch (startPosition)
                {
                    case 0:
                        login = EditText.edit(leftPosition + 2 + menu[0].Length, 0, login);
                        break;
                    case 1:
                        password = enterPassword(leftPosition + 2 + menu[1].Length);
                        break;
                    case 2:
                        sucsess = authCheck(login, password, logins);
                        if (!sucsess) {
                            Console.SetCursorPosition(0, 4);
                            Console.WriteLine("Вы ввели не верный логин или пароль, попробуйте еще.");
                            Console.ReadKey();
                            Console.SetCursorPosition(0, 4);
                            Console.WriteLine("                                                    ");
                                    
                            for (int i = 0; i < login.ToCharArray().Length; i++) {
                                Console.SetCursorPosition(leftPosition + 3 + menu[0].Length + i, 0);
                                Console.Write("\b \b");
                            }

                            for (int i = 0; i < password.ToCharArray().Length; i++)
                            {
                                Console.SetCursorPosition(leftPosition + 3 + menu[1].Length + i, 1);
                                Console.Write("\b \b");
                            }

                            login = "";
                            password = "";
                        }
                        break;
                    case -1:
                        escape = true;
                        break;
                }

            } while (!escape && !sucsess);
            return sucsess;
        }

        private static string enterPassword(int leftPosition)
        {
            Console.SetCursorPosition(leftPosition, 1);
            bool exit = false;
            ConsoleKeyInfo key;
            string password = "";
            do
            {
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        exit = true;
                        break;
                    case ConsoleKey.Escape:
                        exit = true;
                        password = "";
                        break;
                    case ConsoleKey.Backspace:
                        if (password.Length > 0) { 
                            password = password.Substring(0, password.Length - 1);
                            Console.SetCursorPosition(leftPosition + password.Length + 1, 1);
                            Console.Write("\b \b");
                        } else
                            Console.SetCursorPosition(leftPosition, 1);
                        break;
                    default:
                        Console.SetCursorPosition(leftPosition + password.Length, 1);
                        Console.Write("*");
                        password += key.KeyChar;
                        break;
                }
            } while (!exit);

            return password;
        }

        private static bool authCheck(string login, string pass, List<Login> logins) {
            bool auth = false;

            foreach (Login log in logins) {
                if (log.UserLogin.Equals(login) && log.Password.Equals(pass))
                {
                    auth = true;
                    id = log.Id;
                    break;
                }
            }

            return auth;
        }

        public static int getId() {
            return id;
        }
    }
}

