using System;
using System.Linq;

namespace Extras
{
    class Helpers
    {
        public static bool CheckIfPower(int number, int power)
        {
            if (power == Math.Abs(number)) return true;
            if (power > Math.Abs(number)) return false;
            else return CheckIfPower(number, power * 3);
        }

        public static int[] ConvertToBinary(int number, int[] arr, int count)
        {
            if (number == 0) return arr;
            else
            {
                arr[count] = number % 2;
                return ConvertToBinary(number / 2, arr, count - 1);
            }
        }

        public static int CountVowels(string str, int position, int count, char[] vowels)
        {
            if (position == 0) return count;
            else
            {
                if (vowels.Contains(Char.ToLower(str[position]))) count++;
                return CountVowels(str, position - 1, count, vowels);
            }
        }

        public static void Hashes()
        {
            Console.WriteLine();
            Console.WriteLine("####################################################################################################");
            Console.WriteLine();
        }

        public static char[,,] InitializeArray()
        {
            char [,,] elements = new char[,,]
            {
                {
                    {' ', '@', '@', '@', ' '},
                    {'@', ' ', ' ', ' ', '@'},
                    {'@', ' ', ' ', ' ', '@'},
                    {'@', ' ', ' ', ' ', '@'},
                    {'@', ' ', ' ', ' ', '@'},
                    {'@', ' ', ' ', ' ', '@'},
                    {' ', '@', '@', '@', ' '},
                },
                {
                    {' ', ' ', '@', ' ', ' '},
                    {' ', '@', '@', ' ', ' '},
                    {'@', ' ', '@', ' ', ' '},
                    {' ', ' ', '@', ' ', ' '},
                    {' ', ' ', '@', ' ', ' '},
                    {' ', ' ', '@', ' ', ' '},
                    {'@', '@', '@', '@', '@'},
                },
                {
                    {' ', '@', '@', '@', ' '},
                    {'@', ' ', ' ', ' ', '@'},
                    {'@', ' ', ' ', '@', ' '},
                    {' ', ' ', '@', ' ', ' '},
                    {' ', '@', ' ', ' ', ' '},
                    {'@', ' ', ' ', ' ', ' '},
                    {'@', '@', '@', '@', '@'},
                },
                {
                    {' ', '@', '@', '@', ' '},
                    {'@', ' ', ' ', ' ', '@'},
                    {' ', ' ', ' ', ' ', '@'},
                    {' ', '@', '@', '@', ' '},
                    {' ', ' ', ' ', ' ', '@'},
                    {'@', ' ', ' ', ' ', '@'},
                    {' ', '@', '@', '@', ' '},
                },
                {
                    {' ', ' ', ' ', '@', ' '},
                    {' ', ' ', '@', '@', ' '},
                    {' ', '@', ' ', '@', ' '},
                    {'@', ' ', ' ', '@', ' '},
                    {'@', '@', '@', '@', '@'},
                    {' ', ' ', ' ', '@', ' '},
                    {' ', ' ', ' ', '@', ' '},
                },
                {
                    {'@', '@', '@', '@', '@'},
                    {'@', ' ', ' ', ' ', ' '},
                    {'@', '@', '@', '@', ' '},
                    {' ', ' ', ' ', ' ', '@'},
                    {' ', ' ', ' ', ' ', '@'},
                    {'@', ' ', ' ', ' ', '@'},
                    {' ', '@', '@', '@', ' '},
                },
                {
                    {' ', '@', '@', '@', ' '},
                    {'@', ' ', ' ', ' ', '@'},
                    {'@', ' ', ' ', ' ', ' '},
                    {'@', '@', '@', '@', ' '},
                    {'@', ' ', ' ', ' ', '@'},
                    {'@', ' ', ' ', ' ', '@'},
                    {' ', '@', '@', '@', ' '},
                },
                {
                    {'@', '@', '@', '@', '@'},
                    {' ', ' ', ' ', ' ', '@'},
                    {' ', ' ', ' ', '@', ' '},
                    {' ', ' ', '@', ' ', ' '},
                    {' ', ' ', '@', ' ', ' '},
                    {' ', ' ', '@', ' ', ' '},
                    {' ', ' ', '@', ' ', ' '},
                },
                {
                    {' ', '@', '@', '@', ' '},
                    {'@', ' ', ' ', ' ', '@'},
                    {'@', ' ', ' ', ' ', '@'},
                    {' ', '@', '@', '@', ' '},
                    {'@', ' ', ' ', ' ', '@'},
                    {'@', ' ', ' ', ' ', '@'},
                    {' ', '@', '@', '@', ' '},
                },
                {
                    {' ', '@', '@', '@', ' '},
                    {'@', ' ', ' ', ' ', '@'},
                    {'@', ' ', ' ', ' ', '@'},
                    {' ', '@', '@', '@', '@'},
                    {' ', ' ', ' ', ' ', '@'},
                    {'@', ' ', ' ', ' ', '@'},
                    {' ', '@', '@', '@', ' '},
                },
                {
                    {' ', ' ', ' ', ' ', ' '},
                    {' ', ' ', '@', ' ', ' '},
                    {' ', ' ', '@', ' ', ' '},
                    {' ', ' ', ' ', ' ', ' '},
                    {' ', ' ', '@', ' ', ' '},
                    {' ', ' ', '@', ' ', ' '},
                    {' ', ' ', ' ', ' ', ' '},
                },
            };
            return elements;
        }
        
        public static void PrintTime(char[,,] elements, int[] arr)
        {
            for (int index = 0; index < elements.GetLength(1); index++)
            {
                for (int count = 0; count < arr.Length; count++)
                {
                    if (count == 2) for (int i = 0; i < elements.GetLength(2); i++) Console.Write(elements[10, index, i]);
                    for (int i = 0; i < elements.GetLength(2); i++) Console.Write(elements[arr[count], index, i]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}