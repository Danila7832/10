using System;
namespace _10laba.dto
{
    public class myIndex
    {
        private int loginIndex;
        private int tovarIndex;
        private int usersIndex;
        private int buhIndex;

        public myIndex()
        {
        }

        public myIndex(int loginIndex, int tovarIndex, int usersIndex, int buhIndex)
        {
            this.loginIndex = loginIndex;
            this.tovarIndex = tovarIndex;
            this.usersIndex = usersIndex;
            this.buhIndex = buhIndex;
        }

        public int LoginIndex { get => loginIndex; set => loginIndex = value; }
        public int TovarIndex { get => tovarIndex; set => tovarIndex = value; }
        public int UsersIndex { get => usersIndex; set => usersIndex = value; }
        public int BuhIndex { get => buhIndex; set => buhIndex = value; }
    }
}

