using System;
using System.Collections.Generic;

namespace Lesson_tasks
{
    class Tasks
    {
        public static void Task53()
        {
            Console.Clear();
            Random random = new Random();
            int rows = random.Next(2, 11), columns = random.Next(2, 11);
            int[,] numbers = new int[rows, columns];
            Helpers.FillArray(numbers, 1, 100);
            Console.WriteLine("Задача 53: Задайте двумерный массив. Напишите программу, которая поменяет местами первую и последнюю строку массива.\nЗаполненный массив:\n");
            Helpers.PrintArray(numbers);
            Helpers.ReverseArray(numbers);
            Console.WriteLine("Перевёрнутый массив:");
            Helpers.PrintArray(numbers);
            Helpers.Hashes();
        }

        public static void Task55()
        {
            Console.Clear();
            Random random = new Random();
            int rows = random.Next(2, 11), columns = random.Next(2, 11);
            int[,] numbers = new int[rows, columns];
            Helpers.FillArray(numbers, 1, 100);
            Console.WriteLine("Задача 55: Задайте двумерный массив. Напишите программу, которая заменяет строки на столбцы. В случае, если это невозможно, программа должна вывести сообщение для пользователя.\n");
            if (rows != columns) Console.Write("Невозможно заменить строки на столбцы.\n");
            else
            {
                Console.Write("Заполненный массив:\n");
                Helpers.PrintArray(numbers);
                Helpers.Replace(numbers);
                Console.WriteLine("Перевёрнутый массив:");
                Helpers.PrintArray(numbers);
            }
            Helpers.Hashes();
        }

        public static void Task57()
        {
            Console.Clear();
            Random random = new Random();
            int rows = random.Next(2, 11), columns = random.Next(2, 11);
            int[,] numbers = new int[rows, columns];
            Helpers.FillArray(numbers, 1, 100);
            Dictionary<int,int> frequency = Helpers.CountElements(numbers);
            Console.WriteLine("Задача 57: Составить словарь элементов двумерного массива. Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.\n\n" +
                              "Заполненный массив:\n");
            Helpers.PrintArray(numbers);
            Console.WriteLine("Частотный массив:\n");
            Helpers.PrintDict(frequency);
            Helpers.Hashes();
        }

        public static void Task59()
        {
            Console.Clear();
            Random random = new Random();
            int rows = random.Next(2, 11), columns = random.Next(2, 11);
            int[,] numbers = new int[rows, columns];
            Helpers.FillArray(numbers, 1, 100);
            Console.WriteLine("Задача 59: Задайте двумерный массив из целых чисел. Напишите программу, которая удалит строку и столбец, на пересечении которых расположен наименьший элемент массива.\n\n" +
                              "Заполненный массив:\n");
            Helpers.PrintArray(numbers);
            (int x, int y) element = Helpers.FindMinValue(numbers);
            Console.WriteLine($"Индекс наименьшего элемента: [{element.x}, {element.y}].\nУменьшенный массив:");
            int[,] newNumbers = Helpers.Remove(numbers, element);
            Helpers.PrintArray(newNumbers);
            Helpers.Hashes();
        }
    }
}
