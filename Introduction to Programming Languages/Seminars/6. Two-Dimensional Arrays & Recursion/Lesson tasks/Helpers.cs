using System;

namespace Lesson_tasks
{
    class Helpers
    {
        public static bool CheckTriangle(int[] arr)
        {
            for (int count = 0; count < arr.Length; count++)
            {
                int sum = 0;
                for (int index = 0; index < arr.Length; index++) if (index != count) sum += arr[index];
                if (sum <= arr[count]) return false;
            }
            return true;
        }

        public static int[] ConvertToBinary(int number)
        {
            // Размер массива для записи определяется количеством цифр в двоичном представлении числа.
            int[] result = new int[(int)Math.Log(number, 2) + 1];
            for (int count = result.Length - 1; number > 0; count--, number /= 2) result[count] = number % 2;
            return result;
        }

        public static int[] CopyArray(int[] arr)
        {
            int[] copy = new int[arr.Length];
            for (int count = 0; count < arr.Length; count++) copy[count] = arr[count];
            return copy;
        }

        public static void Fibonacci(int[] arr)
        {
            arr[0] = 0;
            arr[1] = 1;
            for (int count = 2; count < arr.Length; count++) arr[count] = arr[count - 2] + arr[count - 1];
        }
        
        public static void Hashes()
        {
            Console.WriteLine();
            Console.WriteLine("####################################################################################################");
            Console.WriteLine();
        }

        public static void PopulateArray(int[] arr, int min, int max)
        {
            Random random = new Random();
            for (int count = 0; count < arr.Length; count++) arr[count] = random.Next(min, max);
        }

        public static void PrintArray(int[] arr)
        {
            for (int count = 0; count < arr.Length; count++)
            {
                if (count == arr.Length - 1) Console.WriteLine($"{arr[count]}]");
                else if (count == 0) Console.Write($"[{arr[count]}, ");
                else Console.Write($"{arr[count]}, ");
            }
        }
    }
}