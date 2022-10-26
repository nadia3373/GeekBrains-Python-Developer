using System;

namespace Task
{
    class Helpers
    {
        public static void Hashes()
        {
            Console.WriteLine();
            for (int count = 0; count < Console.WindowWidth; count++) Console.Write("#");
            Console.WriteLine();
        }

        public static void FillArray(string[] arr)
        {
            for (int count = 0; count < arr.Length; count++)
            arr[count] = GenerateString(1, 16);
        }

        public static string[] FilterByLength(string[] arr, int length)
        {
            string[] output = new string[0];
            for (int count = 0; count < arr.Length; count++)
            if(arr[count].Length <= length)
            {
                Array.Resize(ref output, output.Length + 1);
                output[output.Length - 1] = arr[count];
            }
            return output;
        }

        public static int CountStrings(string[] arr, int length)
        {
            int count = 0;
            for (int index = 0; index < arr.Length; index++)
            if (arr[index].Length <= length) count++;
            return count;
        }

        public static string[] FilterByLengthAlt(string[] arr, int length)
        {
            string[] output = new string[CountStrings(arr, length)];
            for(int count = 0, index = 0; count < arr.Length; count++)
            if(arr[count].Length <= length)
            {
                output[index] = arr[count];
                index++;
            }
            return output;
        }

        public static string GenerateString(int min, int max)
        {
            Random random = new Random();
            int length = random.Next(min, max);
            string str = String.Empty;
            while(length > 0)
            {
                char element = (char)random.Next(33, 127);
                str += element;
                length--;
            }
            return str;
        }

        public static void PrintArray(string[] arr)
        {
            int size = arr.Length;
            for (int count = 0; count < size; count++)
            Console.Write($"{(count == 0 ? size == 1 ? $"[\"{arr[count]}\"]" : $"[\"{arr[count]}\", " : count == size - 1 ? $"\"{arr[count]}\"]" : $"\"{arr[count]}\", ")}");
        }
    }
}