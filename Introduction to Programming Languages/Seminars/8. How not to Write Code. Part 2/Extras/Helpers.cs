using System;
using System.Collections.Generic;
using System.Threading;

namespace Extras
{
    class Helpers
    {
        #region Common
        public static void FillArray(int[,] arr, int min, int max)
        {
            Random random = new Random();
            int firstLength = arr.GetLength(0), secondLength = arr.GetLength(1);
            for (int firstCount = 0; firstCount < firstLength; firstCount++)
            for (int secondCount = 0; secondCount < secondLength; secondCount++) arr[firstCount, secondCount] = random.Next(min, max);
        }

        public static void Hashes()
        {
            Console.WriteLine();
            for (int count = 0; count < Console.WindowWidth; count++) Console.Write("#");
            Console.WriteLine("\n");
        }

        public static int IncreaseToMultiple(int number)
        {
            if (number % 8 == 0) return number;
            else return IncreaseToMultiple(number += 1);
        }

        public static void PrintArray<T>(T[,] arr, int posX = -1)
        {
            Random random = new Random();
            int firstLength = arr.GetLength(0), secondLength = arr.GetLength(1);
            for (int firstCount = 0; firstCount < firstLength; firstCount++)
            {
                if (posX != -1) Console.SetCursorPosition(posX, Console.CursorTop);
                for (int secondCount = 0; secondCount < secondLength; secondCount++) Console.Write($"{arr[firstCount, secondCount]}\t");
                Console.WriteLine();
            }
        }

        public static void PrintDict(Dictionary<int,int> dict)
        {
            foreach (var element in dict) Console.WriteLine($"{element.Key} встречается {element.Value} раз(а).");
        }
        #endregion

        #region Task1
        public static void ReplaceRows(int[,] arr)
        {
            int rows = arr.GetLength(0) - 1, columns = arr.GetLength(1) - 1;
            for (int count = 1; count < columns; count++)
            {
                arr[0, count] = arr[count, count];
                arr[rows, count] = arr[rows - count, count];
            }
            (arr[0, columns], arr[rows, columns]) = (arr[rows, columns], arr[0, columns]);
        }
        #endregion

        #region Task2
        public static Dictionary<int,int> CountElements(int[,] arr)
        {
            Dictionary<int,int> frequency = new Dictionary<int, int>();
            for (int count = 0; count < arr.GetLength(0); count++)
            {
                for (int index = 0; index < arr.GetLength(1); index++)
                {
                    if (!frequency.ContainsKey(arr[count, index])) frequency.Add(arr[count, index], 1);
                    else frequency[arr[count, index]]++;
                }
            }
            return frequency;
        }
        #endregion

        #region Task3
        public static int GetAbsoluteMinimum(int[,] arr)
        {
            int min = Int32.MaxValue;
            for (int count = 0; count < arr.GetLength(0); count++)
            {
                for (int index = 0; index < arr.GetLength(1); index++)
                if (Math.Abs(arr[count, index]) < min) min = Math.Abs(arr[count, index]);
            }
            return min;
        }

        public static void FindEqualElements(int[,] arr, int num, string type)
        {
            List<int> printedIndices = new List<int>();
            Console.Write($"{(type == "rows" ? "Строки: " : "Столбцы: ")}");
            for (int count = 0; count < arr.GetLength(0); count++)
            {
                for (int index = 0; index < arr.GetLength(1); index++)
                {
                    if (Math.Abs(arr[count, index]) == num)
                    {
                        if (type == "rows" && !printedIndices.Contains(count))
                        {
                            Console.Write($"{count} ");
                            printedIndices.Add(count);
                        }
                        else if (type == "columns" && !printedIndices.Contains(index))
                        {
                            Console.Write($"{index} ");
                            printedIndices.Add(index);
                        }
                    }
                }
            }
        }
        #endregion

        #region Task4
        public static void PrintNicely(int[,] arr)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 2);
            Helpers.PrintArray(arr);
            Thread.Sleep(100);
        }

        public static void SnakeFill(int[,] arr, int column = 0, int count = 1)
        {
            if (count > arr.GetLength(0) * arr.GetLength(1))
            {
                PrintNicely(arr);
                return;
            }
            else
            {
                if (column % 2 == 0) for (int row = 0; row < arr.GetLength(0); count++, row++)
                {
                    arr[row, column] = count;
                    PrintNicely(arr);
                }
                else for (int row = arr.GetLength(0) - 1; row >= 0; count++, row--)
                {
                    arr[row, column] = count;
                    PrintNicely(arr);
                }
                SnakeFill(arr, column + 1, count);
            }
        }

        public static void SnakeFillAlt(int[,] arr)
        {
            for (int count = 0; count < arr.GetLength(0); count++)
            {
                for (int index = 0; index < arr.GetLength(1); index++)
                arr[count, index] = count == 0 ? index == 0 ? 1 : index % 2 == 1 ? arr[count, index] = arr.GetLength(0) * (index + 1) : 
                arr[count, index] = arr[count, index - 1] + 1 : index % 2 == 1 ? arr[count - 1, index] - 1 : arr[count - 1, index] + 1;
            }
        }
        #endregion
    }
}