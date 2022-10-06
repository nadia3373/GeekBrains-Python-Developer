using System;

namespace Homework
{
    class Helpers
    {
        public static double[] ArithmeticMean(int[,] arr)
        {
            int rows = arr.GetLength(0), columns = arr.GetLength(1);
            double[] result = new double[columns];
            for (int index = 0; index < columns; index++)
            {
                for (int count = 0; count < rows; count++) result[index] += arr[count, index];
                result[index] = Math.Round(result[index] / rows, 1);
            }
            return result;
        }

        public static void FillArray(double[,] arr, int min, int max)
        {
            Random random = new Random();
            for (int count = 0; count < arr.GetLength(0); count++)
            for (int index = 0; index < arr.GetLength(1); index++) arr[count, index] = Math.Round(random.NextDouble() * (max - min) + min, 1);
        }

        public static void FillArray(int[,] arr, int min, int max)
        {
            Random random = new Random();
            for (int count = 0; count < arr.GetLength(0); count++)
            for (int index = 0; index < arr.GetLength(1); index++) arr[count, index] = random.Next(min, max);
        }

        public static int GetElement(int[,] arr, int element)
        {
            int row = (int)Math.Floor((double)element / arr.GetLength(1));
            int column = element % arr.GetLength(1);
            return arr[row, column];
        }

        public static void Hashes()
        {
            Console.WriteLine();
            Console.WriteLine("####################################################################################################");
            Console.WriteLine();
        }

        public static void PrintArray<T>(T[,] arr)
        {
            Console.WriteLine();
            for (int count = 0; count < arr.GetLength(0); count++)
            {
                for (int index = 0; index < arr.GetLength(1); index++)
                {
                    if (index == arr.GetLength(1) - 1) Console.WriteLine($"{arr[count, index], 5}");
                    else Console.Write($"{arr[count, index], 5}\t");
                }
            }
            Console.WriteLine();
        }

        public static void PrintArray(double[] arr)
        {
            for (int count = 0; count < arr.Length; count++)
            {
                if (count == arr.Length - 1) Console.WriteLine($"{arr[count], 5}");
                else Console.Write($"{arr[count], 5}\t");
            }
        }
    }
}