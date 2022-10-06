using System;
using System.Linq;

namespace Homework
{
    class Tasks
    {
        public static void Task47()
        {
            Console.WriteLine("Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.");
            Random random = new Random();
            int rows = random.Next(4, 11), columns = random.Next(4, 11);
            double[,] numbers = new double[rows, columns];
            Helpers.FillArray(numbers, -10, 10);
            Console.WriteLine($"Массив размером {rows}x{columns}: ");
            Helpers.PrintArray(numbers);
            Helpers.Hashes();
        }

        public static void Task50()
        {
            Random random = new Random();
            int rows = random.Next(4, 11), columns = random.Next(4, 11);
            int[,] numbers = new int[rows, columns];
            Helpers.FillArray(numbers, -10000, 10000);
            Console.WriteLine("Задача 50: Напишите программу, которая на вход принимает индексы элемента в двумерном массиве, " +
                              $"и возвращает значение этого элемента или же указание, что такого элемента нет.\nМассив размером {rows}x{columns}: ");
            Helpers.PrintArray(numbers);
            Console.Write("Введите строку и столбец элемента через пробел: ");
            int[] address = Array.ConvertAll(Console.ReadLine().Split(), Convert.ToInt32);
            Console.WriteLine($@"{(address[0] >= 0 && address[0] < numbers.GetLength(0) && address[1] >= 0 && address[1] < numbers.GetLength(1)?
                              $"Элемент массива на позиции [{address[0]}, {address[1]}]: {numbers[address[0], address[1]]}" :
                              "Такого элемента в массиве нет")}.");
            Helpers.Hashes();
        }

        public static void Task50Alt()
        {
            // Альтернативный вариант – принимает на вход порядковый номер элемента массива.
            // 4, 5, 2, 7
            // 3, 6, 8, 3
            // 9, 3, 1, 2
            // Например: 0 -> 4, 7 -> 3, 11 -> 2
            Random random = new Random();
            int rows = random.Next(4, 11), columns = random.Next(4, 11);
            int[,] numbers = new int[rows, columns];
            Helpers.FillArray(numbers, -10000, 10000);
            Console.WriteLine("Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, " +
                              $"и возвращает значение этого элемента или же указание, что такого элемента нет.\nМассив размером {rows}x{columns}: ");
            Helpers.PrintArray(numbers);
            Console.Write("Введите номер позиции элемента (нумерация позиций начинается с 0): ");
            int address = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($@"{(address >= 0 && address < numbers.GetLength(0) * numbers.GetLength(1) ?
                              $"Элемент массива на позиции {address}: {Helpers.GetElement(numbers, address)}" :
                              "Такого элемента в массиве нет")}.");
            Helpers.Hashes();
        }

        public static void Task52()
        {
            Random random = new Random();
            int rows = random.Next(4, 11), columns = random.Next(4, 11);
            int[,] numbers = new int[rows, columns];
            Helpers.FillArray(numbers, -100, 100);
            Console.WriteLine("Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.\n" +
                              $"Массив размером {rows}x{columns}: ");
            Helpers.PrintArray(numbers);
            double[] result = Helpers.ArithmeticMean(numbers);
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Helpers.PrintArray(result);
            Helpers.Hashes();
        }
    }
}