using dotSpace.Interfaces.Space;
using dotSpace.Objects.Space;
using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            SequentialSpace inbox = new SequentialSpace();
            inbox.Put("Hello world!");
            ITuple tuple = inbox.Get(typeof(string));
            Console.WriteLine(tuple);
            Console.Read();
        }
    }
}
