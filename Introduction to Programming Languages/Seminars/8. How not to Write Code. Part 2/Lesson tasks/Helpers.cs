using System;
using System.Collections.Generic;

namespace Lesson_tasks
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
            foreach (var element in dict)
            {
                Console.WriteLine($"{element.Key} встречается {element.Value} раз(а).");
            }
        }
        #endregion

        #region Task53
        public static void ReverseArray(int[,] arr)
        {
            int max = arr.GetLength(0) - 1;
            for (int count = 0; count < arr.GetLength(1); count++)
            (arr[0, count], arr[max, count]) = (arr[max, count], arr[0, count]);
        }
        #endregion

        #region Task55
        public static void Replace(int[,] arr)
        {
            for (int count = 0; count < arr.GetLength(0); count++)
            {
                for (int index = count; index < arr.GetLength(1); index++)
                (arr[count, index], arr[index, count]) = (arr[index, count], arr[count, index]);
            }
        }
        #endregion

        #region Task57
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

        #region Task59
        public static (int x, int y) FindMinValue(int[,] arr)
        {
            int min = Int32.MaxValue, x = 0, y = 0;
            for (int count = 0; count < arr.GetLength(0); count++)
            {
                for (int index = 0; index < arr.GetLength(1); index++)
                {
                    if (arr[count, index] < min)
                    {
                        min = arr[count, index];
                        x = count;
                        y = index;
                    }
                }
            }
            return (x, y);
        }

        public static int[,] Remove(int[,] arr, (int x, int y) element)
        {
            int[,] numbers = new int[arr.GetLength(0) - 1, arr.GetLength(1) - 1];
            for (int row = 0; row < arr.GetLength(0) - 1; row++)
            {
                for (int column = 0; column < arr.GetLength(1) - 1; column++)
                {
                    if (row < element.x && column < element.y) numbers[row, column] = arr[row, column];
                    else if (row >= element.x && column >= element.y) numbers[row, column] = arr[row + 1, column + 1];
                    else if (row >= element.x && column < element.y) numbers[row, column] = arr[row + 1, column];
                    else if (row < element.x && column >= element.y) numbers[row, column] = arr[row, column + 1];
                }
            }
            return numbers;
        }
        #endregion
    }
}