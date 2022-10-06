using System;
using System.Linq;

namespace Homework
{
    class Tasks
    {
        public static void Task47()
        {
            Console.WriteLine("Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.");
            int rows = 0, columns = 0;
            do 
            {
                try
                {
                    Console.Write("Введите количество строк: ");
                    rows = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите количество столбцов: ");
                    columns = Convert.ToInt32(Console.ReadLine());
                    if (rows < 1 || columns < 1) throw new Exception($"Оба значения должны быть больше 0.");
                }
                catch (Exception error)
                {
                    Console.WriteLine($"Ошибка: {error.Message}");
                }
            }
            while (rows < 1 || columns < 1);
            double[,] numbers = new double[rows, columns];
            Helpers.FillArray(numbers, -10, 10);
            Helpers.PrintArray(numbers);
            Helpers.Hashes();
        }

        public static void Task50()
        {
            Random random = new Random();
            int[,] numbers = new int[random.Next(2, 11), random.Next(2, 11)];
            Helpers.FillArray(numbers, -10000, 10000);
            Console.WriteLine("Задача 50: Напишите программу, которая на вход принимает индексы элемента в двумерном массиве, " +
                              "и возвращает значение этого элемента или же указание, что такого элемента нет.\nЗаполненный массив: ");
            Helpers.PrintArray(numbers);
            Console.Write("Введите строку и столбец элемента через пробел: ");
            int[] address = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Console.WriteLine($@"{(address[0] >= 0 && address[0] < numbers.GetLength(0) && address[1] >= 0 && address[1] < numbers.GetLength(1)?
                              $"Элемент массива на позиции [{address[0]}, {address[1]}]: {numbers[address[0], address[1]]}" :
                              "Такого элемента в массиве нет")}.");
            Helpers.Hashes();
        }

        public static void Task52()
        {
            Random random = new Random();
            int[,] numbers = new int[random.Next(2, 11), random.Next(2, 11)];
            Helpers.FillArray(numbers, -100, 100);
            Console.WriteLine("Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.\nЗаполненный массив: ");
            Helpers.PrintArray(numbers);
            double[] result = Helpers.ArithmeticMean(numbers);
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Helpers.PrintArray(result);
            Helpers.Hashes();
        }
    }
}