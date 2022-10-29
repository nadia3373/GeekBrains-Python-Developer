using System;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Variants.Variant1();
            Console.Write("Нажмите 'Enter' для перехода к следующему варианту.");
            if (Console.ReadKey().Key == ConsoleKey.Enter) Variants.Variant2();
            Console.Write("Нажмите 'Enter' для перехода к следующему варианту.");
            if (Console.ReadKey().Key == ConsoleKey.Enter) Variants.Variant3();
        }
    }
}
