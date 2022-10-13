using System;

namespace Extras
{
    class Tasks
    {
        public static void Task1()
        {
            Console.Clear();
            Console.Write("Задача 1. Дано предложение. Напишите рекурсивный метод, подсчитывающий количество слов в данном предложении. Словом считается последовательность символов без пробелов.\n" +
                          "Введите предложение: ");
            Console.WriteLine($"Количество слов в предложении: {Helpers.CountWords(Console.ReadLine())}");
            Helpers.Hashes();
        }

        public static void Task2() // Неформатированный вывод, печатается быстро.
        {
            Console.Clear();
            Console.WriteLine("Задача 2. Известно, что пароль длиной 3 символа состоит из латинских букв строчного регистра и цифр от 0 до 9. " +
                              "Напишите рекурсивный метод, который перебирает все комбинации паролей.\n");
            char[] options = new char[36];
            Helpers.FillLettersNumbers(options, 0, (char)48, (char)57);
            Helpers.FillLettersNumbers(options, 10, (char)97, (char)122);
            Helpers.GenerateCombinations(options, new char[3], options.Length - 1, 0, 3);
            Console.WriteLine();
            Helpers.Hashes();
        }

        public static void Task2Alt() // Форматированный вывод, печатается долго.
        {
            Console.Clear();
            Console.WriteLine("Задача 2. Известно, что пароль длиной 3 символа состоит из латинских букв строчного регистра и цифр от 0 до 9. " +
                              "Напишите рекурсивный метод, который перебирает все комбинации паролей.\n");
            char[] options = new char[36];
            Helpers.FillLettersNumbers(options, 0, (char)48, (char)57);
            Helpers.FillLettersNumbers(options, 10, (char)97, (char)122);
            Helpers.GenerateCombinationsAlt(options, new char[3], options.Length - 1, 0, 3);
            Console.WriteLine();
            Helpers.Hashes();
        }

        public static void Task3()
        {
            Console.Clear();
            Console.WriteLine("Задача 3. Даны два числа a, b. Сложите их, используя только операции инкремента и декремента.");
            Random random = new Random();
            int a = random.Next(-9, 10), b = random.Next(-9, 10);
            Console.WriteLine($"Сумма чисел {a} и {b} равна {Helpers.SumNumbers(Math.Min(a, b), Math.Max(a, b))}.");
            Helpers.Hashes();
        }

        public static void Task4()
        {
            Console.Clear();
            Console.WriteLine("Задача 4. Даны два числа a, b. Перемножьте их, используя только операции инкремента и декремента.");
            Random random = new Random();
            int a = random.Next(-9, 10), b = random.Next(-9, 10);
            Console.WriteLine($@"Произведение чисел {a} и {b} равно {(a < 0 && b > 0 || a > 0 && b < 0 ?
                              $"-{Helpers.MultiplyNumbers(Math.Abs(a), Math.Abs(b))}" : a == 0 || b == 0 ? "0" : $"{Helpers.MultiplyNumbers(Math.Abs(a), Math.Abs(b))}")}.");
            Helpers.Hashes();
        }
    }
}