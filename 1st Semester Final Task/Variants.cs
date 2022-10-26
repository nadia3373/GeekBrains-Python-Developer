using System;

namespace Task
{
    class Variants
    {
        public static void Variant1()
        {
            Console.Clear();
            string[] source = Array.Empty<string>();
            Console.Write("Каким образом заполнить массив? Нажмите Space, чтобы заполнить автоматически, Enter – чтобы заполнить вручную: ");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                Console.Write("Введите размер массива: ");
                int size = Convert.ToInt32(Console.ReadLine());
                source = new string[size];
                for (int count = 0; count < source.Length; count++)
                {
                    Console.Write("Введите строку: ");
                    source[count] = Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine();
                source = new string[new Random().Next(1, 10)];
                Helpers.FillArray(source);
            }
            Helpers.PrintArray(source);
            Console.Write("     ->     ");
            string[] output = Helpers.FilterByLength(source, 3);
            Helpers.PrintArray(output);
            Helpers.Hashes();
        }

        public static void Variant2()
        {
            Console.Clear();
            string[] source = Array.Empty<string>();
            Console.Write("Каким образом заполнить массив? Нажмите Space, чтобы заполнить автоматически, Enter – чтобы заполнить вручную: ");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                Console.Write("Введите размер массива: ");
                int size = Convert.ToInt32(Console.ReadLine());
                source = new string[size];
                for (int count = 0; count < source.Length; count++)
                {
                    Console.Write("Введите строку: ");
                    source[count] = Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine();
                source = new string[new Random().Next(1, 10)];
                Helpers.FillArray(source);
            }
            Helpers.PrintArray(source);
            Console.Write("     ->     ");
            string[] output = Helpers.FilterByLengthAlt(source, 3);
            Helpers.PrintArray(output);
            Helpers.Hashes();
        }

        public static void Variant3()
        {

        }
    }
}