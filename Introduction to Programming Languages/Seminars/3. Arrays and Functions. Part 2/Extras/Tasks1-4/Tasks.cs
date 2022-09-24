namespace Extras
{
    class Programs
    {
        public static void Task1()
        {
            Console.Write("Задача 1. Рассчитать значение y при заданном x по формуле: y = sin^2x при x > 0, 1-2sinx^2 в противном случае.\nВведите x: ");
            double x = Convert.ToDouble(Console.ReadLine()), y = 0;
            y = x > 0 ? Math.Pow(Math.Sin(x), 2) : 1 - 2 * Math.Sin(Math.Pow(x, 2));
            Console.Write($"При x = {x} y = {y}");
        }

        public static void Task2()
        {
            Console.Write("Задача 2. Дано трёхзначное число N. Определить кратна ли трём сумма всех его цифр. Введите число: ");
            int number = Convert.ToInt32(Console.ReadLine());
            // Согласно формулировке признака делимости на 3: целое число делится на 3, если сумма его цифр делится на 3.
            Console.WriteLine(number % 3 == 0 ? $"Сумма цифра числа {number} делится на 3." : $"Сумма цифра числа {number} не делится на 3.");
        }

        public static void Task3()
        {
            Console.Write("Задача 3. Дано трёхзначное число N. Определить, есть ли среди его цифр 4 или 7.\nВведите число: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Число {number} {Helpers.CheckIfContains(number)}");
        }

        public static void Task4()
        {
            Console.WriteLine("Задача 4. Дан массив длиной 10 элементов. Заполнить его последовательно числами от 1 до 10.");
            int[] arr = Helpers.PopulateArray(new int[10]);
            foreach (int element in arr) Console.Write(element);
        }
    }

}