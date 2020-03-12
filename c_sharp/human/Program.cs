using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Human Mary = new Human("Mary");
            Human Charles = new Human ("Charles");
            Console.WriteLine("Victims Health is {0}", Mary.Attack(Charles));
            Console.WriteLine("Victims Health is {0}", Charles.Attack(Mary));
        }
    }
}
