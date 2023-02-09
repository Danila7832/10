using System;
namespace _10laba.dto
{
    public class Prilavok : Tovar
    {
        private int tovarCount;

        public Prilavok(int id, string name, int count, int price, int tovarCount) : base(id, name, count, price)
        {
            this.TovarCount = tovarCount;
        }

        public int TovarCount { get => tovarCount; set => tovarCount = value; }
    }
}

