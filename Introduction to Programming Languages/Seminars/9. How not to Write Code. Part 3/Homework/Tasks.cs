using System;
using System.Linq;

namespace Homework
{
    class Tasks
    {
        public static void Task64()
        {
            Console.Clear();
            Console.Write("Задача 64. Задайте значения M и N. Напишите рекурсивный метод, который выведет все натуральные числа кратные 3-ём в промежутке от M до N.\n" +
                          "Нажмите M, чтобы задать числа вручную, любую другую букву – чтобы выбрать случайно: ");
            Random random = new Random();
            (int m, int n) numbers = Helpers.TakeInput();
            Console.Write($"Все числа, кратные 3, в промежутке от {numbers.m} до {numbers.n}: ");
            Helpers.PrintElements(Math.Min(numbers.m, numbers.n), Math.Max(numbers.m, numbers.n));
            Console.WriteLine();
            Helpers.Hashes();
        }

        public static void Task66() // Решение с помощью рекурсии
        {
            Console.Clear();
            Console.Write("Задача 66: Задайте значения M и N. Напишите рекурсивный метод, который найдёт сумму натуральных элементов в промежутке от M до N.\n" +
                          "Нажмите M, чтобы задать числа вручную, любую другую букву – чтобы выбрать случайно: ");
            Random random = new Random();
            (int m, int n) numbers = Helpers.TakeInput();
            Console.WriteLine($"Сумма элементов от {numbers.m} до {numbers.n} -> {Helpers.SumElements(Math.Min(numbers.m, numbers.n), Math.Max(numbers.m, numbers.n), 0)}");
            Helpers.Hashes();
        }

        public static void Task66Alt() // Решение с помощью Linq
        {
            Console.Clear();
            Console.Write("Задача 66: Задайте значения M и N. Напишите рекурсивный метод, который найдёт сумму натуральных элементов в промежутке от M до N.\n" +
                          "Нажмите M, чтобы задать числа вручную, любую другую букву – чтобы выбрать случайно: ");
            Random random = new Random();
            (int m, int n) numbers = Helpers.TakeInput();
            Console.WriteLine($@"Сумма элементов от {numbers.m} до {numbers.n} -> {Enumerable.Range(Math.Min(numbers.m, numbers.n),
                              Math.Max(numbers.m, numbers.n) - Math.Min(numbers.m, numbers.n) + 1).Sum()}");
            Helpers.Hashes();
        }

        public static void Task68()
        {
            Console.Clear();
            Console.WriteLine("Задача 68: Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.");
            (int m, int n) numbers = (0, 0);
            Console.Write("Введите m: ");
            numbers.m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите n: ");
            numbers.n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($@"{(numbers.m >= 0 && numbers.n >= 0 ? $"m = {numbers.m}, n = {numbers.n} -> A(m, n) = " +
                              $"{Helpers.Ackermann(numbers.m, numbers.n)}" : "Оба числа должны быть больше или равны 0.")}");
            Helpers.Hashes();
        }
    }
}