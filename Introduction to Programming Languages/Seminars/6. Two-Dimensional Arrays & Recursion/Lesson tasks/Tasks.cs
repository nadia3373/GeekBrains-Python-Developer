using System;
using System.Linq;

namespace Lesson_tasks
{
    class Tasks
    {
        public static void Task39()
        {
            Random random = new Random();
            Console.WriteLine("Задача 39: Напишите программу, которая перевернёт одномерный массив (последний элемент будет на первом месте, а первый - на последнем и т.д.)");
            int[] numbers = new int[random.Next(10, 16)];
            Helpers.PopulateArray(numbers,1, 100);
            Console.Write("Заполненный массив: ");
            Helpers.PrintArray(numbers);
            Array.Reverse(numbers);
            Console.Write("Перевёрнутый массив: ");
            Helpers.PrintArray(numbers);
            Helpers.Hashes();
        }

        public static void Task40()
        {
            Console.Write("Задача 40: Напишите программу, которая принимает на вход три числа и проверяет, может ли существовать треугольник со сторонами такой длины.\n" +
                          "Введите числа через пробел: ");
            int[] numbers = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            if (numbers.Length != 3) Console.WriteLine("Некорректное количество сторон.");
            else Console.WriteLine($"Треугольник с такими сторонами {(Helpers.CheckTriangle(numbers) ? "может" : "не может")} существовать.");
            Helpers.Hashes();
        }

        public static void Task42()
        {
            Console.Write("Задача 42: Напишите программу, которая будет преобразовывать десятичное число в двоичное.\nВведите число: ");
            int number = Convert.ToInt32(Console.ReadLine());
            int[] binary = Helpers.ConvertToBinary(number);
            Console.Write($"Двоичное представление числа {number} -> ");
            for (int count = 0; count < binary.Length; count++)
            {
                if (count == binary.Length - 1) Console.WriteLine($"{binary[count]}.");
                else Console.Write(binary[count]);
            }
            Helpers.Hashes();
        }

        public static void Task44()
        {
            Console.Write("Задача 44: Не используя рекурсию, выведите первые N чисел Фибоначчи. Первые два числа Фибоначчи: 0 и 1.\nСколько чисел вывести? ");
            int size = Convert.ToInt32(Console.ReadLine());
            if (size == 1) Console.WriteLine("Первое число Фибоначчи: 0.");
            else if (size > 1)
            {
                int[] numbers = new int[size];
                Helpers.Fibonacci(numbers);
                Console.Write($"Первые {size} из чисел Фибоначчи: ");
                Helpers.PrintArray(numbers);
            }
            else Console.WriteLine("Введено некорректное количество.");
            Helpers.Hashes();
        }

        public static void Task45()
        {
            Console.Write("Задача 45: Напишите программу, которая будет создавать копию заданного массива с помощью поэлементного копирования.\nВведите элементы массива через пробел: ");
            int[] numbers = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            Console.Write("Полученный массив: ");
            Helpers.PrintArray(numbers);
            int[] copy = Helpers.CopyArray(numbers);
            Console.Write("Скопированный массив: ");
            Helpers.PrintArray(copy);
            Helpers.Hashes();
        }
    }
}