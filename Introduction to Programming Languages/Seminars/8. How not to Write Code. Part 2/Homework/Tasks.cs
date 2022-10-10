using System;

namespace Homework
{
    class Tasks
    {
        public static void Task54()
        {
            Console.Clear();
            // Создать и заполнить массив.
            Random random = new Random();
            int rows = random.Next(4, 11), columns = random.Next(4, 11);
            int[,] numbers = new int[rows, columns];
            Helpers.FillArray(numbers, 1, 10);
            // Определить позиции для вывода массивов рядом, вывести на экран условие задачи и заполненный массив.
            int secondPosition = Console.WindowWidth / 2;
            secondPosition = secondPosition % 8 == 0 ? secondPosition : Helpers.IncreaseToMultiple(secondPosition);
            Console.WriteLine("Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.\n\n" +
                              $"Заполненный массив размером {rows}x{columns}:\n");
            Helpers.PrintArray(numbers);
            // Отсортировать и напечатать массив.
            Helpers.DescendingSort(numbers);
            Console.SetCursorPosition(secondPosition, 2);
            Console.WriteLine("Отсортированный массив:\n");
            Helpers.PrintArray(numbers, secondPosition);
            Helpers.Hashes();
        }

        public static void Task56()
        {
            Console.Clear();
            Random random = new Random();
            int rows = random.Next(4, 11), columns = 0;
            do columns = random.Next(4, 11);
            while (rows == columns);
            int[,] numbers = new int[rows, columns];
            Helpers.FillArray(numbers, 1, 10);
            Console.WriteLine("Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.\n\n" +
                              $"Заполненный массив размером {rows}x{columns}:\n");
            Helpers.PrintArray(numbers);
            Console.WriteLine($"\nСтрока с минимальной суммой элементов: {Helpers.FindMinRow(numbers) + 1}.");
            Helpers.Hashes();
        }

        public static void Task58()
        {
            Console.Clear();
            // Создать и заполнить 2 матрицы и матрицу-результат их умножения.
            Random random = new Random();
            int rows = random.Next(2, 9), columns = random.Next(2, 9);
            int[,] matrix1 = new int[rows, columns], matrix2 = new int[columns, rows];
            Helpers.FillArray(matrix1, 1, 10);
            Helpers.FillArray(matrix2, 1, 10);
            int[,] result = Helpers.MultiplyMatrices(matrix1, matrix2);
            // Определить позиции для вывода матриц рядом.
            int secondPosition = Console.WindowWidth / 3, thirdPosition = Console.WindowWidth / 3 * 2;
            secondPosition = secondPosition % 8 == 0 ? secondPosition : Helpers.IncreaseToMultiple(secondPosition);
            thirdPosition = thirdPosition % 8 == 0 ? thirdPosition : Helpers.IncreaseToMultiple(thirdPosition);
            // Вывести на экран условие задачи и все 3 матрицы.
            Console.WriteLine("Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.\n\n" +
                              $"Матрица 1 размером {rows}x{columns}:\n");
            Helpers.PrintArray(matrix1);
            Console.SetCursorPosition(secondPosition, 2);
            Console.WriteLine($"Матрица 2 размером {columns}x{rows}:\n");
            Helpers.PrintArray(matrix2, secondPosition);
            Console.SetCursorPosition(thirdPosition, 2);
            Console.WriteLine("Результат умножения матриц:\n");
            Helpers.PrintArray(result, thirdPosition);
            Console.SetCursorPosition(Console.CursorLeft, 4 + Math.Max(rows, columns));
            Helpers.Hashes();
        }

        public static void Task60()
        {
            Console.Clear();
            Random random = new Random();
            int size = random.Next(2, 5);
            int[,,] numbers = new int[size, size, size];
            Helpers.FillArray(numbers, 10, 100);
            Console.WriteLine("Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. " +
                              "Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.\n\n" +
                              $"Массив размером {size}x{size}x{size}:\n");
            Helpers.PrintArray(numbers);
            Helpers.Hashes();
        }

        public static void Task62()
        {
            Console.Clear();
            // Создать массив случайного размера для заполнения по спирали, а также массив для хранения граничных индексов и счётчика элементов.
            // positions[0] - начальная строка, positions[1] – начальный столбец, positions[2] граничная строка, positions[3] – граничный столбец, positions[4] – счётчик.
            Random random = new Random();
            int rows = random.Next(4, 11), columns = random.Next(4, 11);
            string[,] numbers = new string[rows, columns];
            int[] positions = {0, 0, rows, columns, 1};
            // Заполнить и напечатать массив.
            Helpers.FillSpirally(positions, numbers);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.\n\nМассив размером {rows}x{columns}:");
            Console.SetCursorPosition(0, 5 + rows);
            Helpers.Hashes();
        }
    }
} 