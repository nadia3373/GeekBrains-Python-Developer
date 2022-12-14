using System;
using System.Linq;

namespace Task
{
    class Helpers
    {
        #region Common
        public static string[] FillArray(string[] arr)
        {
            // Функция автоматического заполнения массива.
            for (int count = 0; count < arr.Length; count++)
            arr[count] = GenerateString(1, 11);
            return arr;
        }

        public static string[] FilterByLength(string[] arr, int length, string type = "")
        {
            // Функция фильтрации элементов искомой длины и записи их в новый массив.
            string[] output = type == "" ? new string[0] : new string[CountStrings(arr, length)];
            if (type == "")
            {
                for (int count = 0; count < arr.Length; count++)
                {
                    if(arr[count].Length <= length)
                    {
                        Array.Resize(ref output, output.Length + 1);
                        output[output.Length - 1] = arr[count];
                    }
                }
            }
            else
            {
                for(int count = 0, index = 0; count < arr.Length; count++)
                if(arr[count].Length <= length)
                {
                    output[index] = arr[count];
                    index++;
                }
            }
            return output;
        }

        public static string GenerateString(int min, int max)
        {
            // Функция генерации строки.
            Random random = new Random();
            string str = String.Empty;
            for (int length = random.Next(min, max); length > 0; length--) str += (char)random.Next(33, 127);
            return str;
        }

        public static void Hashes()
        {
            // Печать хэштегов после выполнения программы.
            Console.WriteLine("\n");
            for (int count = 0; count < Console.WindowWidth; count++) Console.Write("#");
            Console.WriteLine("\n");
        }

        public static void PrintArray(string[] arr)
        {
            // Печать элементов массива.
            int size = arr.Length;
            Console.Write("[");
            for (int count = 0; count < size; count++) Console.Write($"{(count == size - 1 ? $"\"{arr[count]}\"" : $"\"{arr[count]}\", ")}");
            Console.Write("]");
        }

        public static string[] GetArray(int variant = 0)
        {
            // Выбор типа заполнения массива и заполнение массива.
            string[] source = Array.Empty<string>();
            Console.Write("Каким образом заполнить массив? Нажмите Enter, чтобы заполнить вручную, любую другую клавишу – чтобы заполнить автоматически.");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Write("\nВведите строки через пробел: ");
                source = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                if (variant == 3) source = new string[new Random().Next(1, 16)].Select(n => GenerateString(1, 11)).ToArray();
                else source = FillArray(new string[new Random().Next(1, 16)]);
            }
            return source;
        }
        #endregion

        #region Variant2
        public static int CountStrings(string[] arr, int length)
        {
            // Подсчёт строк искомой длины.
            int count = 0;
            for (int index = 0; index < arr.Length; index++)
            if (arr[index].Length <= length) count++;
            return count;
        }
        #endregion
    }
}