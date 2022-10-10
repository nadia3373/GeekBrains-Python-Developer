using System;

namespace Extras
{
    class Tasks
    {
        public static void Task1()
        {
            Console.Clear();
            Random random = new Random();
            int rows = random.Next(2, 9), columns = random.Next(2, 9);
            int[,] matrix1 = new int[rows, columns], matrix2 = new int[columns, rows];
            Console.WriteLine("Задача 1. Даны две матрицы, количество строк и столбцов которых может быть 3 или 4, заполнены числами от -9 до 9. Выполните умножение матриц.\n" +
                              $"Дополнительный материал по задаче: https://portal.tpu.ru/SHARED/k/KONVAL/Sites/Russian_sites/1/04.htm\n\n" +
                               $"Матрица 1 размером {rows}x{columns}: ");
            Helpers.FillArray(matrix1, -9, 10);
            Helpers.FillArray(matrix2, -9, 10);
            Helpers.PrintArray(matrix1);
            Console.SetCursorPosition(72, 3);
            Console.WriteLine($"Матрица 2 размером {columns}x{rows}: ");
            Helpers.PrintArray(matrix2, 72);
            int[,] result = Helpers.MultiplyMatrices(matrix1, matrix2);
            Console.SetCursorPosition(144, 3);
            Console.WriteLine("Результат умножения матриц: ");
            Helpers.PrintArray(result, 144);
            Console.SetCursorPosition(Console.CursorLeft, 5 + Math.Max(rows, columns));
            Helpers.Hashes();
        }

        public static void Task2()
        {
            Console.Clear();
            Random random = new Random();
            int rows = random.Next(2, 8), columns = random.Next(2, 8);
            int[,] numbers = new int[rows, columns];
            Helpers.FillArray(numbers, 100, 1000);
            Console.WriteLine("Задача 2. Двумерный массив размером 3х4 заполнен числами от 100 до 9999. " +
                              $"Найдите в этом массиве и сохраните в одномерный массив все числа, сумма цифр которых больше их произведения. Выведите оба массива.\n\n" +
                              $"Заполненный исходный массив размером {rows}x{columns}: ");
            Helpers.PrintArray(numbers);
            int[] result = Helpers.FindNumbers(numbers);
            if (result.Length > 0)
            {
                Console.Write("Все числа из исходного массива, сумма цифр которых больше их произведения: ");
                Helpers.PrintArray(result);
            }
            else Console.WriteLine($"В исходном массиве нет чисел, сумма цифр которых больше их произведения.");
            Helpers.Hashes();
        }

        public static void Task3()
        {
            Console.Clear();
            Random random = new Random();
            int rows = random.Next(4, 15), columns = random.Next(4, 15);
            string[,] numbers = new string[rows, columns];
            Helpers.FillArray(numbers, 0, 2);
            // string[,] numbers = {
            // {"1", "1", "1", "1", "1", "1", "1"},
            // {"1", "1", "1", "1", "0", "1", "1"},
            // {"1", "0", "0", "1", "1", "0", "1"},
            // {"1", "1", "1", "1", "0", "1", "1"},
            // {"1", "1", "0", "1", "1", "1", "1"},
            // {"1", "1", "1", "1", "0", "0", "1"},
            // {"1", "1", "1", "1", "1", "1", "1"},
            // };
            numbers[0, 0] = "S";
            numbers[numbers.GetLength(0) - 1, numbers.GetLength(1) - 1] = "F";
            Console.WriteLine("Задача 3. Двумерный массив размером 5х5 заполнен случайными нулями и единицами. Игрок может ходить только по полям, заполненным единицами. " +
                            $"Проверьте, существует ли путь из точки [0, 0] в точку [4, 4] (эти поля требуется принудительно задать равными единице).\n" +
                            $"Массив размером {rows}x{columns}");
            Helpers.PrintArray(numbers);
            Helpers.PrintWithoutGaps(numbers);
            bool[,] check = new bool[numbers.GetLength(0), numbers.GetLength(1)];
            for (int count = 0; count < check.GetLength(0); count++)
            for (int index = 0; index < check.GetLength(1); index++) check[count, index] = false;
            Console.WriteLine($"{(Helpers.FindPath(numbers, 0, 0, check) ? "Из лабиринта есть выход." : "Из лабиринта нет выхода.")}");
            Helpers.Hashes();
        }
    }
}