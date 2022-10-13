using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Tasks.Task64();
            Console.Write("Нажмите 'Enter' для перехода к следующему заданию.");
            if (Console.ReadKey().Key == ConsoleKey.Enter) Tasks.Task66();
            Console.Write("Нажмите 'Enter' для перехода к следующему заданию.");
            if (Console.ReadKey().Key == ConsoleKey.Enter) Tasks.Task66Alt();
            Console.Write("Нажмите 'Enter' для перехода к следующему заданию.");
            if (Console.ReadKey().Key == ConsoleKey.Enter) Tasks.Task68();
        }
    }
}