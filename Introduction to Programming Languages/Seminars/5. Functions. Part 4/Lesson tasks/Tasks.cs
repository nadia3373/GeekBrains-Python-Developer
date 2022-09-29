namespace Lesson
{
    class Tasks
    {
        public static void Task31()
        {
            Console.WriteLine("Задача 31: Задайте массив из 12 элементов, заполненный случайными числами из промежутка [-9, 9]. Найдите сумму отрицательных и положительных элементов массива.");
            int[] numbers = new int[12];
            Helpers.FillArray(numbers, -9, 10);
            Console.WriteLine("Заполненный массив: ");
            Helpers.PrintArray(numbers);
            int positive = Helpers.Calculate("positive", arr: numbers), negative = Helpers.Calculate("negative", arr: numbers);
            Console.WriteLine($"Сумма отрицательных чисел = {negative}, положительных = {positive}");
            Helpers.Hashes();
        }

        public static void Task32()
        {
            Console.WriteLine("Задача 32: Напишите программу замены элементов массива: положительные элементы замените на соответствующие отрицательные, и наоборот.");
            int[] numbers = new int[12];
            Helpers.FillArray(numbers, -9, 10);
            Console.WriteLine("Заполненный массив: ");
            Helpers.PrintArray(numbers);
            Helpers.ReverseNumbers(numbers);
            Console.WriteLine("Перевёрнутый массив: ");
            Helpers.PrintArray(numbers);
            Helpers.Hashes();
        }

        public static void Task33()
        {
            Console.WriteLine("Задача 33: Задайте массив. Напишите программу, которая определяет, присутствует ли заданное число в массиве.");
            int[] numbers = new int[12];
            Helpers.FillArray(numbers, -9, 10);
            Console.WriteLine("Заполненный массив: ");
            Helpers.PrintArray(numbers);
            Console.Write("Введите число для поиска: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Число {number} {(Array.Exists(numbers, element => element == number) ? "есть" : "отсутствует")} в массиве.");
        }

        public static void Task35()
        {
            Console.WriteLine("Задача 35: Задайте одномерный массив из 10 случайных чисел. Найдите количество элементов массива, значения которых лежат в отрезке [10,99].");
            Random random = new Random();
            int[] numbers = new int[10];
            Helpers.FillArray(numbers, -1000, 1000);
            Console.WriteLine("Заполненный массив: ");
            Helpers.PrintArray(numbers);
            int count = Helpers.Calculate("range", arr: numbers, min: 10, max: 99);
            Console.WriteLine($"Количество чисел из диапазона [10, 99]: {count}");
        }

        public static void Task38()
        {
            Console.WriteLine("Задача 37: Найдите произведение пар чисел в одномерном массиве. Парой считаем первый и последний элемент, второй и предпоследний и т.д. Результат запишите в новом массиве.");
            int[] numbers = new int[12];
            Helpers.FillArray(numbers, -9, 10);
            Console.WriteLine("Заполненный массив: ");
            Helpers.PrintArray(numbers);
            int[] products = Helpers.FindProducts(numbers);
            Console.WriteLine("Произведения чисел: ");
            for (int count = 1; count <= products.Length; count++) Console.WriteLine($"{numbers[count - 1], 2} * {numbers[numbers.Length - count], 2} -> {products[count - 1], 3}");
        }
    }
}