using System;
using System.Data;
using System.Reflection;
using _10laba.dto;

namespace _10laba
{
    public class AdminMenu:Crud
    {
        private int findId = -1;
        private string findName = "";
        private string findPassword = "";
        private Roles findRole = Roles.Администратор;
        private bool rolesFind = false;

        public void draw()
        {
            //кнопочное управление
            ConsoleKey key;
            do
            {
                //чищу данные и боковое меню
                DrawMenu.clearData(SaveLoad.Logins.Count + 20, 0, 100, 2);
                DrawMenu.clearData(25, 102, 200, 2);

                //подгатавливаем таблицу для данных
                String[] menuNames = { "ID", "Логин", "Пароль", "Роль" };
                int[] menuItemSize = { 15, 30, 33, 20 };

                //формируем данные для вывода и отрисовываем
                List<String[]> data = new List<string[]>(); ;

                foreach (Login log in SaveLoad.Logins.FindAll(
                    delegate(Login log) {
                        return log.Id.ToString().Contains(findId.ToString()) || findId == -1; 
                    }
                    ).FindAll(
                        delegate (Login log)
                        {
                            return log.UserLogin.Contains(findName) || findName == "";
                        }
                    ).FindAll(
                        delegate (Login log){
                            return log.Password.Contains(findPassword) || findPassword == "";
	                    }
                    ).FindAll(
                        delegate (Login log) {
                            return (rolesFind && log.Role == findRole) || !rolesFind;
                        }
                    )
                    )
                {
                    string[] row = { log.Id.ToString(), log.UserLogin, log.Password, log.Role.ToString() };
                    data.Add(row);
                }
                DrawMenu.drawData(menuNames, menuItemSize, data);

                //рисуем боковое меню
                String[] sideMenu = { "F1 - Добавить запись", "F2 - Добавить параметр поиска", "F3 - Сбросить фильтры поиска"};
                DrawMenu.draw(sideMenu, 110, 3);
                printHelp();

                int startPosition = 0;
                bool enter = false;
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        startPosition = DrawMenu.arrowNavigation(startPosition, SaveLoad.Logins.Count, 3);
                        enter = true;
                        break;
                    case ConsoleKey.DownArrow:
                        startPosition = DrawMenu.arrowNavigation(startPosition, SaveLoad.Logins.Count, 3);
                        enter = true;
                        break;
                    case ConsoleKey.F1:
                        create();
                        break;
                    case ConsoleKey.F2:
                        find();
                        break;
                    case ConsoleKey.F3:
                        rolesFind = false;
                        findId = -1;
                        findName = "";
                        findPassword = "";
                        break;    
                }
                if (enter && startPosition >= 0)
                {
                    read(startPosition);
                }

            } while (key != ConsoleKey.Escape);
        }

        public void delete(int index)
        {
            SaveLoad.Logins.Remove(SaveLoad.Logins[index]);

            //отчистка бокового меню
            DrawMenu.clearData(25, 102, 200, 2);

            Console.SetCursorPosition(110, 3);
            Console.Write("Запись удалена!");
            Thread.Sleep(2000);
        }

        public void read(int startPosition)
        {
            //кнопочное управление
            ConsoleKeyInfo key;
            bool deleteFlag = false;
            do
            {
                //чищу данные и боковое меню
                DrawMenu.clearData(SaveLoad.Logins.Count + 20, 0, 100, 2);
                DrawMenu.clearData(25, 102, 200, 2);

                //отрисовка детальных данных
                string[] fields = { "ID: ", "Логин: ", "Пароль: ", "Роль: " };
                Login login = SaveLoad.Logins[startPosition - 3];
                string[] userDetails = { login.Id.ToString(), login.UserLogin, login.Password, login.Role.ToString() };
                DrawMenu.menu(fields, userDetails, 2, 2);

                //отрисовка бокового меню
                string[] menu = { "F1 - Изменить данные", "F2 - Удалить запись целиком" };
                DrawMenu.draw(menu, 110, 3);
                printHelp();

                int currentPosition = 1;
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.F1:
                        update(fields, startPosition - 3);
                        break;
                    case ConsoleKey.F2:
                        if (login.Id == 0)
                        {
                            //отчистка бокового меню
                            DrawMenu.clearData(25, 102, 200, 2);

                            Console.SetCursorPosition(110, 3);
                            Console.Write("Нельзя удалять администратора!");
                            Thread.Sleep(3000);
                        }
                        else
                        {
                            delete(startPosition - 3);
                            deleteFlag = true;
                        }   
                        break;
                }

            } while (key.Key != ConsoleKey.Escape && !deleteFlag);

        }

        public void update(String[] fields, int index)
        {   //отчистка бокового меню
            DrawMenu.clearData(25, 102, 200, 2);

            //отрисовка бокового меню
            string[] sideFields = { "      ", " ", " ", " ", " ", " " };
            string[] roles = {"Роли:", Roles.Администратор.ToString(), Roles.HR.ToString(), Roles.Бухгалтер.ToString(),
                Roles.Кассир.ToString(), Roles.Менеджер_склада.ToString()};
            DrawMenu.menu(sideFields, roles, 3, 110);
            Console.SetCursorPosition(110, 16);
            Console.Write("Для сохранения нажмите F1, для выхода escape");


            ConsoleKeyInfo key;
            string login = SaveLoad.Logins[index].UserLogin;
            string password = SaveLoad.Logins[index].Password;
            string role = SaveLoad.Logins[index].Role.ToString();
            
            bool sucsess = false;
            do
            {
                int startPosition = 0;
                key = Console.ReadKey();
                //отчистка сообщения об ошибке
                DrawMenu.clearData(1, 0, 100, 8);

                if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.DownArrow)
                {
                    startPosition = DrawMenu.arrowNavigation(startPosition, 3, 3) - 3;
                    switch (startPosition)
                    {
                        case 0:
                            login = EditText.edit(2 + fields[1].Length, startPosition + 3, login);
                            break;
                        case 1:
                            password = EditText.edit(2 + fields[2].Length, startPosition + 3, password);
                            break;
                        case 2:
                            role = EditText.edit(2 + fields[3].Length, startPosition + 3, role);
                            break;
                    }
                }

                if (key.Key == ConsoleKey.F1) {
                    Roles roles1;
                    if (Enum.TryParse(role, out roles1) && login.Length > 0 && password.Length > 0)
                    {
                        SaveLoad.Logins[index].Role = roles1;
                        SaveLoad.Logins[index].UserLogin = login;
                        SaveLoad.Logins[index].Password = password;

                        //отчистка бокового меню
                        DrawMenu.clearData(25, 102, 200, 2);

                        Console.SetCursorPosition(110, 3);
                        Console.Write("Изменения сохранены!");
                        sucsess = true;
                        Thread.Sleep(2000);
                    }
                    else {
                        Console.SetCursorPosition(2, 8);
                        Console.Write("Вы неправильно ввели роль или один из параметров пустой, попробуйте снова");
                    }
                }

            } while (key.Key != ConsoleKey.Escape && !sucsess);

            //отчистка стрелочного меню
            //DrawMenu.clearData(fields.Length, 0, 3, 2);
        }

        public void create()
        {
            //чищу данные и боковое меню
            DrawMenu.clearData(SaveLoad.Logins.Count + 20, 0, 100, 2);
            DrawMenu.clearData(25, 102, 200, 2);

            //отрисовка формыы
            string[] fields = { "ID: ", "Логин: ", "Пароль: ", "Роль: " };
            DrawMenu.emptyMenu(fields, 2, 2);

            //отрисовка бокового меню
            string[] sideFields = { "      ", " ", " ", " ", " ", " " };
            string[] roles = {"Роли:", Roles.Администратор.ToString(), Roles.HR.ToString(), Roles.Бухгалтер.ToString(),
                Roles.Кассир.ToString(), Roles.Менеджер_склада.ToString()};
            DrawMenu.menu(sideFields, roles, 3, 110);
            Console.SetCursorPosition(110, 16);
            Console.Write("Для сохранения нажмите F1, для выхода escape");
            Console.SetCursorPosition(110, 17);
            Console.Write("Параметр ID проставляется автоматически после сохранения");

            //кнопочное управление
            ConsoleKeyInfo key;
            string login = "";
            string password = "";
            string role = "";
            int startPosition = 0;
            bool sucsess = false;
            do
            {
                key = Console.ReadKey();
                //отчистка сообщения об ошибке
                DrawMenu.clearData(1, 0, 100, 8);

                if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.DownArrow)
                {
                    startPosition = DrawMenu.arrowNavigation(startPosition, 3, 3) - 3;
                    switch (startPosition)
                    {
                        case 0:
                            login = EditText.edit(2 + fields[1].Length, startPosition + 3, login);
                            break;
                        case 1:
                            password = EditText.edit(2 + fields[2].Length, startPosition + 3, password);
                            break;
                        case 2:
                            role = EditText.edit(2 + fields[3].Length, startPosition + 3, role);
                            break;
                    }
                }

                if (key.Key == ConsoleKey.F1)
                {
                    Roles roles1;
                    if (Enum.TryParse(role, out roles1) && login.Length > 0 && password.Length > 0)
                    {
                        SaveLoad.Logins.Add(new Login(SaveLoad.MyIndixes.LoginIndex, login, password, roles1));
                        SaveLoad.MyIndixes.LoginIndex++;

                        //отчистка бокового меню
                        DrawMenu.clearData(25, 102, 200, 2);

                        Console.SetCursorPosition(110, 3);
                        Console.Write("Запись добавлена!");
                        sucsess = true;
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.SetCursorPosition(2, 8);
                        Console.Write("Вы неправильно ввели роль или один из параметров пустой, попробуйте снова");
                    }
                }

            } while (key.Key != ConsoleKey.Escape && !sucsess);
        }

        public void find() {
            //кнопочное управление
            ConsoleKeyInfo key;
            bool enter = false;
            do
            {
                //чищу данные и боковое меню
                DrawMenu.clearData(SaveLoad.Logins.Count + 20, 0, 100, 2);
                DrawMenu.clearData(25, 102, 200, 2);

                //отрисовка пунктов поиска
                string[] fields = {"Выберите параметр для поиска", "ID", "Логин", "Пароль", "Роль" };
                DrawMenu.emptyMenu(fields, 2, 2);


                //отрисовка бокового меню
                printHelp();

                int startPosition = 0;
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.DownArrow)
                {
                    startPosition = DrawMenu.arrowNavigation(startPosition, fields.Length - 1, 3) - 3;
                    string[] find = { "Введите значение для поиска"};
                    DrawMenu.emptyMenu(find, 0, 2 + fields.Length + 2);
                    Console.SetCursorPosition(0, 2 + fields.Length + 3);
                    String value = Console.ReadLine();
                    enter = true;

                    if (value != "" && value != null)
                    {
                        switch (startPosition)
                        {
                            case 0:
                                int.TryParse(value, out findId);
                                break;
                            case 1:
                                findName = value;
                                break;
                            case 2:
                                findPassword = value;
                                break;
                            case 3:
                                Enum.TryParse(value, out findRole);
                                rolesFind = true;
                                break;
                        }
                    }
                }

            } while (key.Key != ConsoleKey.Escape && !enter);
        }

        private void printHelp() {
            Console.SetCursorPosition(110, 7);
            Console.Write("Для переключения по списку нажимайте стрелочки вверх или вниз");
            Console.SetCursorPosition(110, 8);
            Console.Write("Для выбора данных нажмите enter. Для выхода из выбора нажмите escape");
            Console.SetCursorPosition(110, 9);
            Console.Write("Для выхода на предыдущее меню нажмите escape вне выбора данных");
        }
    }
}

