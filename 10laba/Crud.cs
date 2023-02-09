using System;
namespace _10laba
{
    public interface Crud
    {
        void create();

        void read(int startPosition);

        void update(String[] fields, int index);

        void delete(int index);

        void find();
    }
}

