using System;

namespace Lesson_tasks
{
    class Tasks
    {
        public static void Task63()
        {
            Console.Clear();
            Console.WriteLine("Задача 63: Задайте значение N. Напишите программу, которая выведет все натуральные числа в промежутке от 1 до N.");
            Random random = new Random();
            int number = random.Next(-20, 20);
            Console.Write($"\nN = {number} -> ");
            Helpers.PrintNumbers(number);
            Helpers.Hashes();
        }

        public static void Task65()
        {
            Console.Clear();
            Console.WriteLine("Задача 65: Задайте значения M и N. Напишите программу, которая выведет все натуральные числа в промежутке от M до N.");
            Random random = new Random();
            (int m, int n) numbers = (random.Next(1, 100), random.Next(1, 100));
            Console.Write($"Все числа в промежутке от {numbers.m} до {numbers.n}: ");
            Helpers.PrintNumbers(numbers.n, numbers.m);
            Helpers.Hashes();
        }

        public static void Task67()
        {
            Console.Clear();
            Console.WriteLine("Задача 67: Напишите программу, которая будет принимать на вход число и возвращать сумму его цифр.");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Сумма цифр числа {number} равна: {Helpers.SumDigits(number)}");
            Helpers.Hashes();
        }

        public static void Task69()
        {
            Console.Clear();
            Console.Write("Задача 69: Напишите программу, которая на вход принимает два числа A и B, и возводит число А в целую степень B с помощью рекурсии.\nВведите a: ");
            (int a, int b) numbers;
            numbers.a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите b: ");
            numbers.b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{numbers.a} в степени {numbers.b} = {Helpers.Power(numbers.a, numbers.b)}");
            Helpers.Hashes();
        }
    }
}