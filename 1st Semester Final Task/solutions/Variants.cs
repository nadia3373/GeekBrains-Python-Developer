using System;
using System.Linq;

namespace Task
{
    class Variants
    {
        public static void Variant1()
        {
            Console.Clear();
            // Выбрать тип заполнения массива и заполнить массив.
            string[] source = Helpers.GetArray();
            Console.Clear();
            // Вывести элементы исходного массива.
            Helpers.PrintArray(source);
            Console.Write("     ->     ");
            // Отфильтровать элементы массива искомой длины.
            string[] output = Helpers.FilterByLength(source, 3);
            // Вывести элементы итогового массива.
            Helpers.PrintArray(output);
            Helpers.Hashes();
        }

        public static void Variant2()
        {
            Console.Clear();
            // Выбрать тип заполнения массива и заполнить массив.
            string[] source = Helpers.GetArray();
            Console.Clear();
            // Вывести элементы исходного массива.
            Helpers.PrintArray(source);
            Console.Write("     ->     ");
            // Отфильтровать элементы массива искомой длины.
            string[] output = Helpers.FilterByLength(source, 3, "count");
            // Вывести элементы итогового массива.
            Helpers.PrintArray(output);
            Helpers.Hashes();
        }

        public static void Variant3()
        {
            Console.Clear();
            // Выбрать тип заполнения массива и заполнить массив.
            string[] source = Helpers.GetArray(3);
            Console.Clear();
            // Вывести элементы исходного массива.
            Helpers.PrintArray(source);
            Console.Write("     ->     ");
            // Отфильтровать элементы массива искомой длины.
            string[] output = source.Where(n => n.Length <= 3).ToArray();
            // Вывести элементы итогового массива.
            Helpers.PrintArray(output);
            Helpers.Hashes();
        }
    }
}