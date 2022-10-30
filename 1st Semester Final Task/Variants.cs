using System;
using System.Linq;

namespace Task
{
    class Variants
    {
        public static void Variant1()
        {
            Console.Clear();
            string[] source = Helpers.TakeInput();
            Console.Clear();
            Helpers.PrintArray(source);
            Console.Write("     ->     ");
            string[] output = Helpers.FilterByLength(source, 3);
            Helpers.PrintArray(output);
            Helpers.Hashes();
        }

        public static void Variant2() // Самый быстрый вариант.
        {
            Console.Clear();
            string[] source = Helpers.TakeInput();
            Console.Clear();
            Helpers.PrintArray(source);
            Console.Write("     ->     ");
            string[] output = Helpers.FilterByLength(source, 3, "count");
            Helpers.PrintArray(output);
            Helpers.Hashes();
        }

        public static void Variant3()
        {
            Console.Clear();
            string[] source = Helpers.TakeInput(3);
            Console.Clear();
            Helpers.PrintArray(source);
            Console.Write("     ->     ");
            string[] output = source.Where(n => n.Length <= 3).ToArray();
            Helpers.PrintArray(output);
            Helpers.Hashes();
        }
    }
}