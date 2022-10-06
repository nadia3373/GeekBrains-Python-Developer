using System;

namespace Extras
{
    class Tasks
    {
        public static void Task1()
        {
            Console.Write("Задача 1. Написать перевод десятичного числа в двоичное, используя рекурсию.\nВведите число: ");
            int number = Convert.ToInt32(Console.ReadLine());
            // Размер массива для записи определяется количеством цифр в двоичном представлении числа.
            int[] binary = new int[(int)Math.Log(number, 2) + 1];
            Helpers.ConvertToBinary(number, binary, binary.Length - 1);
            Console.Write($"Двоичное представление числа {number} -> ");
            for (int count = 0; count < binary.Length; count++)
            {
                if (count == binary.Length - 1) Console.WriteLine($"{binary[count]}.");
                else Console.Write(binary[count]);
            }
            Helpers.Hashes();
        }

        public static void Task2()
        {
            Console.WriteLine("Задача 2. На вход подаётся поговорка “без труда не выловишь и рыбку из пруда”. Используя рекурсию, подсчитайте, сколько в поговорке гласных букв.");
            string saying = "Без труда не выловишь и рыбку из пруда";
            char[] vowels = {'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я'};
            int count = Helpers.CountVowels(saying, saying.Length - 1, 0, vowels);
            Console.WriteLine($"В поговорке \"без труда не выловишь и рыбку из пруда\" {count} гласных букв.");
            Helpers.Hashes();
        }

        public static void Task3()
        {
            Console.Write("Задача 3. Дано число N. Используя только операцию деления и рекурсию, определите, что оно является степенью числа 3.\nВведите число: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Число {number} {(Helpers.CheckIfPower(number, 3) ? "является" : "не является")} степенью числа 3.");
            Helpers.Hashes();
        }

        public static void Task1Advanced()
        {
            Console.WriteLine("Задача 1*. Создайте программу, показывающую текущее время. Для вывода чисел используйте двумерные массивы.");
            char[,,] elements = Helpers.InitializeArray();
            DateTime datetime = DateTime.Now;
            int[] numbers = {datetime.Hour / 10, datetime.Hour % 10, datetime.Minute / 10, datetime.Minute % 10};
            Helpers.PrintTime(elements, numbers);
            Helpers.Hashes();
        }
    }
}