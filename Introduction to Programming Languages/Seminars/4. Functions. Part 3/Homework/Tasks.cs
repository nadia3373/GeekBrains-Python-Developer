namespace Homework
{
    class Tasks
    {
        public static void Task25()
        {
            while (true)
            {
                try
                {
                    Console.Write("Задача 25: Используя определение степени числа, напишите цикл, который принимает на вход два натуральных числа (A и B) и возводит число A в степень B.\n" +
                                "Введите основание для возведения в степень: ");
                    int number = Convert.ToInt32(Console.ReadLine());
                    Console.Write($"Введите степень, в которую нужно возвести число {number}: ");
                    int power = Convert.ToInt32(Console.ReadLine());
                    if (number < 1 || power < 1) throw new Exception($"Одно из чисел или оба числа не являются натуральными.");
                    Console.WriteLine($"{number} в степени {power} = {Helpers.Power(number, power)}");
                    Helpers.Hashes();
                    break;
                }
                catch (Exception error)
                {
                    Console.WriteLine($"Ошибка: {error.Message}");
                }
            }
        }

        public static void Task27()
        {
            while (true)
            {
                try
                {
                    Console.Write("Задача 27: Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.\nВведите число: ");
                    int number = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Сумма цифр числа {number} равна {Helpers.SumDigits(Math.Abs(number))}");
                    Helpers.Hashes();
                    break;
                }
                catch (Exception error)
                {
                    Console.WriteLine($"Ошибка: {error.Message}");
                }
            }    
        }

        public static void Task29()
        {
            Console.WriteLine("Задача 29: Напишите программу, которая задаёт массив из 8 случайных целых чисел и выводит отсортированный по модулю массив.");
            int[] numbers = Helpers.PopulateArray(new int[8]);
            Console.Write("Массив заполнен числами: ");
            Helpers.PrintArray(numbers);
            Console.Write("Отсортированный по модулю массив: ");
            Helpers.PrintArray(Helpers.SortArray(numbers));
            Helpers.Hashes();
        }
    }
}