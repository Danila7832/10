using System;
namespace _10laba.dto
{
    public class Login
    {
        private int id;
        private string userLogin;
        private string password;
        private Roles role;

        public Login()
        {
        }

        public Login(int id, string userLogin, string password, Roles role)
        {
            this.Id = id;
            this.UserLogin = userLogin;
            this.Password = password;
            this.Role = role;
        }

        public int Id { get => id; set => id = value; }
        public string UserLogin { get => userLogin; set => userLogin = value; }
        public string Password { get => password; set => password = value; }
        public Roles Role { get => role; set => role = value; }
    }
}

