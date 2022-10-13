using System;
using System.Linq;

namespace Extras
{
    class Helpers
    {
        #region Common
        public static void Hashes()
        {
            Console.WriteLine();
            for (int count = 0; count < Console.WindowWidth; count++) Console.Write("#");
            Console.WriteLine();
        }

        public static void PrintArray<T>(T[] arr)
        {
            for (int count = 0; count < arr.Length; count++)
            {
                if (count == arr.Length - 1) Console.Write($"{arr[count]}]");
                else if (count == 0) Console.Write($"\t[{arr[count]}, ");
                else Console.Write($"{arr[count]}, ");
            }
        }
        #endregion

        #region Task1
        public static int CountWords(string sentence, int index = 0, int count = 0)
        {
            if (index == sentence.Length) return sentence[index - 1] == ' ' ? count : count + 1;
            else
            {
                if (sentence[index] == ' ' && index > 0 && sentence[index - 1] != ' ') count++;
                return CountWords(sentence, index + 1, count);
            }
        }
        #endregion

        #region Task2
        public static void GenerateCombinations(char[] arr, char[] comb, int limit, int index, int combLength)
        {
            if (index == combLength)
            {
                // Выводить только те результаты, в которых есть хотя бы одна буква и хотя бы одна цифра.
                if (comb.Any(char.IsDigit) && comb.Any(char.IsLetter)) PrintArray(comb);
                return;
            }
            for (int start = 0; start <= limit && limit > combLength - index; start++)
            {
                comb[index] = arr[start];
                GenerateCombinations(arr, comb, limit, index + 1, combLength);
            }
        }

        public static void FillLettersNumbers(char[] arr, int index, char start, char limit)
        {
            for (char count = start; count <= limit; count++, index++) arr[index] = count;
        }
        #endregion

        #region Task2Alt
        public static void GenerateCombinationsAlt(char[] arr, char[] comb, int limit, int index, int combLength)
        {
            if (index == combLength)
            {
                // Выводить только те результаты, в которых есть хотя бы одна буква и хотя бы одна цифра.
                if (comb.Any(char.IsDigit) && comb.Any(char.IsLetter)) PrintArrayAlt(comb);
                return;
            }
            for (int start = 0; start <= limit && limit > combLength - index; start++)
            {
                comb[index] = arr[start];
                GenerateCombinationsAlt(arr, comb, limit, index + 1, combLength);
            }
        }

        public static void PrintArrayAlt<T>(T[] arr)
        {
            if (Console.CursorLeft + arr.Length + 14 > Console.WindowWidth) Console.WriteLine();
            for (int count = 0; count < arr.Length; count++)
            {
                if (count == arr.Length - 1) Console.Write($"{arr[count]}]");
                else if (count == 0) Console.Write($"\t[{arr[count]}, ");
                else Console.Write($"{arr[count]}, ");
            }
        }
        #endregion

        #region Task3
        public static int SumNumbers(int a, int b)
        {
            if (a == 0) return b;
            else
            {
                if (a >= 0 && b >= 0 || a >= 0 && b <= 0)
                {
                    a--;
                    b++;
                }
                else if (a <= 0 && b >= 0 || a <= 0 && b <= 0)
                {
                    a++;
                    b--;
                }
                return SumNumbers(a, b);
            }
        }
        #endregion

        #region Task4
        public static int MultiplyNumbers(int a, int b, int result = 0)
        {
            if (b == 0) return result;
            else
            {
                int temp = a;
                while (temp > 0)
                {
                    result++;
                    temp--;
                }
                b--;
                return MultiplyNumbers(a, b, result);
            }
        }
        #endregion
    }
}