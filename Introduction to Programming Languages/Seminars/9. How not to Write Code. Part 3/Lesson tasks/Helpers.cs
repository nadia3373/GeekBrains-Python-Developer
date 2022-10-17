using System;

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
        #endregion

        #region Task63
        public static void PrintNumbers(int num, int count = 1)
        {
            if (count == num)
            {
                Console.WriteLine(count);
                return;
            }
            else
            {
                Console.Write($"{count}, ");
                if (num < 1) PrintNumbers(num, count - 1);
                else PrintNumbers(num, count + 1);
            }
        }
        #endregion

        #region Task67
        public static int SumDigits(int number, int result = 0)
        {
            if (number == 0) return result;
            else
            {
                result += number % 10;
                return SumDigits(number / 10, result);
            }
        }
        #endregion

        #region Task69
        public static int Power(int a, int b, int result = 1)
        {
            if (b == 0) return result;
            else return Power(a, b - 1, result * a);
        }
        #endregion
    }
}