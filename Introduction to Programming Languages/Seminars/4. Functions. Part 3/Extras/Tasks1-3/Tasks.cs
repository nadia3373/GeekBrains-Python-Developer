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
                    int binary = Helpers.Copy(number, 2);
                    int copy = Helpers.Copy(binary, 10);
                    Console.Write($"Число {number} в двоичной записи: {binary} -> {copy}. Число {(binary == copy ? "является" : "не является")} палиндромом.");
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
            int[] quantity = new int[2];
            // Генерация количества единиц в диапазоне от 1 до 10, определение размера массива квадратом количества единиц – таким образом, размер не превысит 100.
            quantity[1] = random.Next(1, 11);
            int total = (int)Math.Pow(quantity[1], 2);
            quantity[0] = total - quantity[1];
            Console.Write("Задача 2. Напишите метод, который заполняет массив случайным количеством (от 1 до 100) нулей и единиц. Размер массива должен совпадать с квадратом количества единиц в нём.\n" +
                          $"Размер массива: {total}, количество единиц: {quantity[1]}, количество нулей: {quantity[0]}.\n" +
                          $"Каким образом заполнить массив? (R – случайным образом, любая другая буква – последовательно): ");
            int[] arr = new int[total];
            // Заполнение массива нулями и единицами.
            Helpers.FillArray(arr, quantity, Console.ReadKey().Key == ConsoleKey.R ? "random" : "consecutive");
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