using System;
namespace _10laba.dto
{
    public class User
    {
        private int id;
        private string name;
        private string secondName;
        private string therdName;
        private DateTime bornDate;
        private int docNum;
        private string role;
        private int cash;
        private int loginId;

        public User()
        {
        }

        public User(int id, string name, string secondName, string therdName, DateTime bornDate, int docNum, string role, int cash, int loginId)
        {
            this.Id = id;
            this.Name = name;
            this.SecondName = secondName;
            this.TherdName = therdName;
            this.BornDate = bornDate;
            this.DocNum = docNum;
            this.Role = role;
            this.Cash = cash;
            this.LoginId = loginId;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string SecondName { get => secondName; set => secondName = value; }
        public string TherdName { get => therdName; set => therdName = value; }
        public DateTime BornDate { get => bornDate; set => bornDate = value; }
        public int DocNum { get => docNum; set => docNum = value; }
        public string Role { get => role; set => role = value; }
        public int Cash { get => cash; set => cash = value; }
        public int LoginId { get => loginId; set => loginId = value; }
    }
}

