using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Mee mee1 = new Mee("mee1");
            Mee mee2 = new Mee("mee2");

            mee1.DoObjectStuff();
            mee2.DoObjectStuff();
            Mee.DoClassStuff();
        }
    }

    class Mee
    {
        private string _name;

        public Mee(string name)
        {
            _name = name;
        }

        public void DoObjectStuff()
        {
        }
        public static void DoClassStuff()
        {
        }
    }
}
