using System;
namespace _10laba.dto
{
    public class Buhgaltery
    {
        private int id;
        private string name;
        private int cash;
        private DateTime date;
        private bool plus;

        public Buhgaltery(int id, string name, int cash, DateTime date, bool plus)
        {
            this.Id = id;
            this.Name = name;
            this.Cash = cash;
            this.Date = date;
            this.Plus = plus;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Cash { get => cash; set => cash = value; }
        public DateTime Date { get => date; set => date = value; }
        public bool Plus { get => plus; set => plus = value; }
    }
}

