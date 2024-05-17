using System;

namespace KTPM
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Process a = new Process();
            a.Password = "asdasd";
            Console.WriteLine(a.Password);
        }
    }
}