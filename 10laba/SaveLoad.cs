using System;
using Newtonsoft.Json;
using _10laba.dto;

namespace _10laba
{
    public static class SaveLoad
    {
        private static List<Login> logins;
        private static List<Tovar> tovars;
        private static List<User> users;
        private static List<Prilavok> prilavok;
        private static List<Buhgaltery> buhgaltery;
        private static myIndex myIndixes;

        private const string loginsPath = "../../../../data/logins.json";
        private const string tovarsPath = "../../../../data/sklad.json";
        private const string usersPath = "../../../../data/users.json";
        private const string prilavokPath = "../../../../data/kass.json";
        private const string buhPath = "../../../../data/buhgalteria.json";
        private const string myIndexesPath = "../../../../data/indexes.json";

        public static List<Login> Logins { get => logins; set => logins = value; }
        public static List<Tovar> Tovars { get => tovars; set => tovars = value; }
        public static List<User> Users { get => users; set => users = value; }
        public static List<Prilavok> Prilavok { get => prilavok; set => prilavok = value; }
        public static List<Buhgaltery> Buhgaltery { get => buhgaltery; set => buhgaltery = value; }
        public static myIndex MyIndixes { get => myIndixes; set => myIndixes = value; }

        public static void loadAll() {

            Logins = SaveLoad.load<List<Login>>(loginsPath);
            Tovars = SaveLoad.load<List<Tovar>>(tovarsPath);
            Users = SaveLoad.load<List<User>>(usersPath);
            Prilavok = SaveLoad.load<List<Prilavok>>(prilavokPath);
            Buhgaltery = SaveLoad.load<List<Buhgaltery>>(buhPath);
            MyIndixes = SaveLoad.load<myIndex>(myIndexesPath);

            if (Logins == null)
                Logins = new List<Login>();
            if (Tovars == null)
                Tovars = new List<Tovar>();
            if (Users == null)
                Users = new List<User>();
            if (Prilavok == null)
                Prilavok = new List<Prilavok>();
            if (Buhgaltery == null)
                Buhgaltery = new List<Buhgaltery>();
            if (MyIndixes == null)
                MyIndixes = new myIndex();

        }

        public static void saveAll() {
            save<List<Login>>(loginsPath, Logins);
            save<List<Tovar>>(tovarsPath, tovars);
            save<List<User>>(usersPath, users);
            save<List<Prilavok>>(prilavokPath, prilavok);
            save<List<Buhgaltery>>(buhPath, buhgaltery);
            save<myIndex>(myIndexesPath, myIndixes);
        }

        private static T load<T>(String path) {
            string text = File.ReadAllText(path);
            T result = JsonConvert.DeserializeObject<T>(text);
            return result;
        }

        private static void save<T>(String path, T data) {
            if (data != null)
            {
                string json = JsonConvert.SerializeObject(data);
                File.WriteAllText(path, json);
            }
        }

    }
}

