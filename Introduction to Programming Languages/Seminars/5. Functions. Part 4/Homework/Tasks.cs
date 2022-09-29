namespace Homework
{
    class Tasks
    {
        public static void Task34()
        {
            Console.WriteLine("Задача 34: Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве.");
            Random random = new Random();
            int[] numbers = new int[random.Next(4, 11)];
            Helpers.PopulateArray(numbers, 100, 1000);
            Console.Write("Заполненный массив: ");
            Helpers.PrintArray(numbers);
            Console.WriteLine($"Количество чётных чисел в массиве = {Helpers.CountElements(numbers, "number", "even")}");
            Helpers.Hashes();
        }

        public static void Task36()
        {
            Console.WriteLine("Задача 36: Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов с нечётными индексами.");
            Random random = new Random();
            int[] numbers = new int[random.Next(4, 11)];
            Helpers.PopulateArray(numbers, -99, 100);
            Console.Write("Заполненный массив: ");
            Helpers.PrintArray(numbers);
            Console.WriteLine($"Сумма элементов с нечётными индексами = {Helpers.CountElements(numbers, "index", "odd")}");
            Helpers.Hashes();
        }

        public static void Task38()
        {
            Console.WriteLine("Задача 38: Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.");
            Random random = new Random();
            double[] numbers = new double[random.Next(4, 11)];
            Helpers.PopulateArray(numbers, random.Next(-100, 0), random.Next(0, 100));
            Console.Write("Заполненный массив: ");
            Helpers.PrintArray(numbers);
            double min = numbers.Min(), max = numbers.Max();
            Console.WriteLine($"Максимальный элемент: {max}, минимальный элемент: {min}, абсолютная разница между ними = {Math.Round(max - Math.Abs(min), 2)}, " + 
                              $"разница с учётом знака = {Math.Round(max - min, 2)}.");
            Helpers.Hashes();
        }
    }
}