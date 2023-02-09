using System;
namespace _10laba.dto
{
    public class Tovar
    {

        private int id;
        private string name;
        private int count;
        private int price;

        public Tovar(int id, string name, int count, int price)
        {
            this.Id = id;
            this.Name = name;
            this.Count = count;
            this.Price = price;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Count { get => count; set => count = value; }
        public int Price { get => price; set => price = value; }
    }
}

