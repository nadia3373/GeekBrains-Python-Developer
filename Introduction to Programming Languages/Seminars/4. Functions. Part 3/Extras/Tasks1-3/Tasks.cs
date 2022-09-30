namespace Extras
{
    class Tasks
    {
        public static void Task1()
        {
            while (true)
            {
                try
                {
                    Console.Write("Задача 1. На вход подаётся натуральное десятичное число. Проверьте, является ли оно палиндромом в двоичной записи.\nВведите число: ");
                    int number = Convert.ToInt32(Console.ReadLine());
                    if (number < 1) throw new Exception($"Число {number} не является натуральным.");
                    // Записать двоичное представление числа в массив путём выполнения деления по модулю на 2 и целочисленного деления на 2.
                    int[] binary = Helpers.ConvertToBinary(number);
                    Console.Write($"Число {number} в двоичной записи: ");
                    foreach (int element in binary) Console.Write(element);
                    // Сравнить значения левой и правой сторон массива. Если все значения совпадут, то число является палиндромом. Например, число 585 -> 1001001001.
                    Console.Write($". Число {(Helpers.CheckIfPalindrome(binary) ? "является" : "не является")} палиндромом в двоичной записи.");
                    Helpers.Hashes();
                    break;
                }
                catch (Exception error)
                {
                    Console.WriteLine($"Ошибка: {error.Message}");
                }
            }
        }

        public static void Task2()
        {
            Random random = new Random();
            // Генерация количества единиц в диапазоне от 1 до 10, определение размера массива квадратом количества единиц – таким образом, размер не превысит 100.
            int ones = random.Next(1, 11);
            int total = (int)Math.Pow(ones, 2);
            int zeros = total - ones;
            Console.Write("Задача 2. Напишите метод, который заполняет массив случайным количеством (от 1 до 100) нулей и единиц. Размер массива должен совпадать с квадратом количества единиц в нём.\n" +
                          $"Размер массива: {total}, количество единиц: {ones}, количество нулей: {zeros}.\n" +
                          $"Каким образом заполнить массив? (R – случайным образом, любая другая буква – последовательно): ");
            int[] arr = new int[total];
            // Заполнение массива нулями и единицами.
            Helpers.FillArray(arr, zeros, ones, Console.ReadKey().Key == ConsoleKey.R ? "random" : "consecutive");
            Console.WriteLine("\nЗаполненный массив: ");
            Helpers.PrintArray(arr);
            Helpers.Hashes();
        }

        public static void Task3()
        {
            Console.WriteLine("Задача 3. Массив на 100 элементов задаётся случайными числами от 1 до 99. Определите самый часто встречающийся элемент в массиве. Если таких элементов несколько, вывести их все.");
            // Создание, заполнение и вывод массива.
            int[] numbers = new int[100];
            Helpers.FillArray(numbers);
            Console.Write("Заполненный массив: ");
            Array.Sort(numbers);
            Helpers.PrintArray(numbers);
            // Подсчитать повторяющиеся цифры и записать в массив количество каждой.
            int[] counts = Helpers.CountSequences(numbers);
            // Найти максимальное число в массиве и вывести все индексы с максимальным значением.
            int max = counts.Max();
            string result = String.Empty;
            for (int count = 1; count < counts.Length; count++) if (counts[count] == max) result += $"{count}, ";
            Console.WriteLine($"Наиболее часто встречающиеся в массиве числа: {result.Remove(result.Length - 2)} – {max} раз(а).");
            Helpers.Hashes();
        }
    }
}