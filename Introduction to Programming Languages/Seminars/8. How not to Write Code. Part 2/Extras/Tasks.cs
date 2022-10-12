using System;
using System.Collections.Generic;

namespace Extras
{
    class Tasks
    {
        public static void Task1()
        {
            Console.Clear();
            Random random = new Random();
            int size = random.Next(4, 11);
            int[,] numbers = new int[size, size];
            Helpers.FillArray(numbers, 0, 20);
            int secondPosition = Console.WindowWidth / 2;
            secondPosition = secondPosition % 8 == 0 ? secondPosition : Helpers.IncreaseToMultiple(secondPosition);
            Console.WriteLine("Задача 1. Дан двумерный массив. Заменить в нём элементы первой строки элементами главной диагонали. А элементы последней строки, элементами побочной диагонали.\n\n" +
                              $"Заполненный массив:\n");
            Helpers.PrintArray(numbers);
            Helpers.ReplaceRows(numbers);
            Console.SetCursorPosition(secondPosition, 2);
            Console.WriteLine("С заменёнными строками:\n");
            Helpers.PrintArray(numbers, secondPosition);
            Helpers.Hashes();
        }

        public static void Task2()
        {
            Console.Clear();
            Random random = new Random();
            int rows = random.Next(2, 11), columns = random.Next(2, 11);
            int[,] numbers = new int[rows, columns];
            Helpers.FillArray(numbers, -9, 10);
            Dictionary<int,int> frequency = Helpers.CountElements(numbers);
            int secondPosition = Console.WindowWidth / 2;
            secondPosition = secondPosition % 8 == 0 ? secondPosition : Helpers.IncreaseToMultiple(secondPosition);
            Console.WriteLine("Задача 2. Дан двумерный массив, заполненный случайными числами от -9 до 9. Подсчитать частоту вхождения каждого числа в массив, используя словарь.\n\n");
            Console.SetCursorPosition(secondPosition, 2);
            Console.WriteLine("Заполненный массив:\n");
            Helpers.PrintArray(numbers, secondPosition);
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("Частотный массив:\n");
            Helpers.PrintDict(frequency);
            Helpers.Hashes();
        }

        public static void Task3()
        {
            Console.Clear();
            Random random = new Random();
            int rows = random.Next(2, 11), columns = random.Next(2, 11);
            int[,] numbers = new int[rows, columns];
            Helpers.FillArray(numbers, -20, 21);
            Console.WriteLine("Задача 3. Найти минимальный по модулю элемент. Все столбцы и строки, содержащие элементы, равные по модулю минимальному.\n\n" +
                              "Заполненный массив:\n");
            Helpers.PrintArray(numbers);
            int min = Helpers.GetAbsoluteMinimum(numbers);
            Console.Write($"\nМинимальный по модулю элемент: {min}. ");
            Helpers.FindEqualElements(numbers, min, "rows");
            Helpers.FindEqualElements(numbers, min, "columns");
            Console.WriteLine();
            Helpers.Hashes();
        }

        public static void Task4()
        {
            Console.Clear();
            Random random = new Random();
            int rows = random.Next(2, 11), columns = random.Next(2, 11);
            int[,] numbers = new int[rows, columns];
            Helpers.SnakeFill(numbers); 
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Задача 4. Заполните двумерный массив 3х3 числами от 1 до 9 змейкой.");
            Console.SetCursorPosition(0, 2 + rows);
            Helpers.Hashes();
        }

        public static void Task4Alt()
        {
            Console.Clear();
            Random random = new Random();
            int rows = random.Next(2, 11), columns = random.Next(2, 11);
            int[,] numbers = new int[rows, columns];
            Console.WriteLine("Задача 4. Заполните двумерный массив 3х3 числами от 1 до 9 змейкой.\n");
            Helpers.SnakeFillAlt(numbers);
            Helpers.PrintArray(numbers);
            Helpers.Hashes();
        }
    }
}