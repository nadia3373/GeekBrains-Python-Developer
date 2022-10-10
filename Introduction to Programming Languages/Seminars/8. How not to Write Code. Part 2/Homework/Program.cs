using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Tasks.Task54();
            Console.Write("Нажмите 'Enter' для перехода к следующему заданию.");
            if (Console.ReadKey().Key == ConsoleKey.Enter) Tasks.Task56();
            Console.Write("Нажмите 'Enter' для перехода к следующему заданию.");
            if (Console.ReadKey().Key == ConsoleKey.Enter) Tasks.Task58();
            Console.Write("Нажмите 'Enter' для перехода к следующему заданию.");
            if (Console.ReadKey().Key == ConsoleKey.Enter) Tasks.Task61();
        }
    }
}