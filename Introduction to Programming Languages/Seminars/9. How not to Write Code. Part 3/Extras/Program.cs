using System;

namespace Extras
{
    class Program
    {
        static void Main(string[] args)
        {
            Tasks.Task1();
            Console.Write("\nНажмите 'Enter' для перехода к следующему заданию.");
            if (Console.ReadKey().Key == ConsoleKey.Enter) Tasks.Task2();
            // Console.Write("\nНажмите 'Enter' для перехода к следующему заданию.");
            // if (Console.ReadKey().Key == ConsoleKey.Enter) Tasks.Task2Alt();
            Console.Write("\nНажмите 'Enter' для перехода к следующему заданию.");
            if (Console.ReadKey().Key == ConsoleKey.Enter) Tasks.Task3();
            Console.Write("\nНажмите 'Enter' для перехода к следующему заданию.");
            if (Console.ReadKey().Key == ConsoleKey.Enter) Tasks.Task4();
        }
    }
}
