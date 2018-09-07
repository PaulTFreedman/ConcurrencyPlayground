using System;

namespace ConcurrencyPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            var runner = new DemoRunner();
            runner.Run();

            Console.ReadLine();
        }
    }
}
