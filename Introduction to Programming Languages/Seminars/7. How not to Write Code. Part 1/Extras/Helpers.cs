using System;
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
            Console.WriteLine("####################################################################################################");
            Console.WriteLine();
        }

        public static void PrintArray<T>(T[,] arr, int posX = -1)
        {
            if (posX != -1) Console.SetCursorPosition(posX, Console.CursorTop);
            Console.WriteLine();
            Random random = new Random();
            int firstLength = arr.GetLength(0), secondLength = arr.GetLength(1);
            for (int firstCount = 0; firstCount < firstLength; firstCount++)
            {
                if (posX != -1) Console.SetCursorPosition(posX, Console.CursorTop);
                for (int secondCount = 0; secondCount < secondLength; secondCount++) Console.Write($"{arr[firstCount, secondCount]}\t");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void PrintArray(int[] arr)
        {
            for (int count = 0; count < arr.Length; count++)
            {
                if (arr.Length == 1) Console.WriteLine($"{arr[count]}");
                else if (count == arr.Length - 1) Console.WriteLine($"{arr[count]}]");
                else if (count == 0) Console.Write($"[{arr[count]}, ");
                else Console.Write($"{arr[count]}, ");
            }
        }
        #endregion

        #region Task1
        public static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows1 = matrix1.GetLength(0), cols1 = matrix1.GetLength(1), rows2 = matrix2.GetLength(0), cols2 = matrix2.GetLength(1);
            int[,] result = new int[rows1, cols2];
            for(int firstCount = 0; firstCount < rows1; firstCount++)
            {
                for(int secondCount = 0; secondCount < cols2; secondCount++)
                {
                    int sum = 0;
                    for (int thirdCount = 0; thirdCount < cols1; thirdCount++) sum += matrix1[firstCount, thirdCount] * matrix2[thirdCount, secondCount];
                    result[firstCount, secondCount] = sum;
                }
            }
            return result;
        }
        #endregion

        #region Task2
        public static int[] FindNumbers(int[,] arr)
        {
            int[] result = Array.Empty<int>();
            for (int count = 0; count < arr.GetLength(0); count++)
            {
                for (int index = 0; index < arr.GetLength(1); index++)
                {
                    if (DigitsProduct(arr[count, index]) < DigitsSum(arr[count, index]))
                    {
                        Array.Resize(ref result, result.Length + 1);
                        result[result.Length - 1] = arr[count, index];
                    }
                }
            }
            return result;
        }

        public static int DigitsProduct(int number)
        {
            int digits = (int)Math.Floor(Math.Log10(number));
            int result = 1;
            for (int count = digits; count >= 0; count--) result *= (int)(number / Math.Pow(10, count) % 10);
            return result;
        }

        public static int DigitsSum(int number)
        {
            int digits = (int)Math.Floor(Math.Log10(number));
            int result = 0;
            for (int count = digits; count >= 0; count--) result += (int)(number / Math.Pow(10, count) % 10);
            return result;
        }
        #endregion
        #region Task3
        public static void FillArray(string[,] arr, int min, int max)
        {
            Random random = new Random();
            int firstLength = arr.GetLength(0), secondLength = arr.GetLength(1);
            for (int firstCount = 0; firstCount < firstLength; firstCount++)
            for (int secondCount = 0; secondCount < secondLength; secondCount++) arr[firstCount, secondCount] = Convert.ToString(random.Next(min, max));
        }
        
        public static bool FindPath(string[,] arr, int x, int y, bool[,] check)
        {
            if (x == arr.GetLength(0) - 1 && y == arr.GetLength(1) - 1) return true;
            check[x, y] = true;
            bool esc = false;
            if (validate(arr, x, y + 1, check)) esc = FindPath(arr, x, y + 1, check);
            if (!esc && validate(arr, x + 1, y, check)) esc = FindPath(arr, x + 1, y, check);
            if (!esc && validate(arr, x, y - 1, check)) esc = FindPath(arr, x, y - 1, check);
            if (!esc && validate(arr, x - 1, y, check)) esc = FindPath(arr, x - 1, y, check);
            if (esc) return esc;
            return false;
        }

        public static void PrintWithoutGaps(string[,] arr)
        {
            int firstLength = arr.GetLength(0), secondLength = arr.GetLength(1);
            for (int secondCount = 0; secondCount <= secondLength + 1; secondCount++) Console.Write("_");
            Console.WriteLine();
            for (int firstCount = 0; firstCount < firstLength; firstCount++)
            {
                Console.Write('|');
                for (int secondCount = 0; secondCount < secondLength; secondCount++)
                {
                    Console.Write($"{(arr[firstCount, secondCount] == "0" ? "\u2592" : arr[firstCount, secondCount] == "1" ? " " : arr[firstCount, secondCount])}");
                }
                Console.Write('|');
                Console.WriteLine();
            }
            for (int secondCount = 0; secondCount <= secondLength + 1; secondCount++) Console.Write("\u203E");
            Console.WriteLine();
        }

        public static bool validate(string[,] arr, int x, int y, bool[,] check)
        {
            if (x < 0 || x >= arr.GetLength(0)) return false;
            if (y < 0 || y >= arr.GetLength(1)) return false;
            if (arr[x, y] == "0") return false;
            if (check[x, y] == true) return false;
            arr[x, y] = "*";
            Console.Clear();
            PrintWithoutGaps(arr);
            arr[x, y] = ".";
            Thread.Sleep(300);
            return true;
        }
        #endregion
    }
}