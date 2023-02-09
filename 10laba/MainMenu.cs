using System;
namespace _10laba.dto
{
    public static class MainMenu
    {
        public static void menu()
        {   //связываем данные и рисуем шапку
            Login login = new Login();
           
            foreach (Login log in SaveLoad.Logins) {
                if (log.Id == Auth.getId()) {
                    login = log;
                }
            }

            User user = new User();

            foreach(User user1 in SaveLoad.Users)
            {
                if (user1.LoginId == login.Id) {
                    user = user1;
                }
            }

            if (user.Name == null)
            {
                drawMainMenu(login.Role, login.UserLogin);
            }
            else
                drawMainMenu(login.Role, user.Name);
            //конец

            switch (login.Role) {
                case Roles.Администратор:
                    new AdminMenu().draw();
                    break;

            }
        }


        private static void drawMainMenu(Roles role, string name) {
            Console.Clear();

            Console.SetCursorPosition(40, 0);
            Console.Write("Добро пожаловать, " + name + "!");

            Console.SetCursorPosition(100, 0);
            Console.Write("Роль: " + role);

            for (int i = 0; i < 200; i++) {
                Console.SetCursorPosition(i, 1);
                Console.Write("-");
            }

            for (int i = 2; i < 30; i++) {
                Console.SetCursorPosition(100, i);
                Console.Write("|");
            }
        }
    }
}

