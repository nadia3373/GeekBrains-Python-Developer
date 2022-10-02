namespace Extras
{
    class Tasks
    {
        public static void Task1()
        {
            int[] numbers = new int[15];
            Helpers.FillArray(numbers, 0, 10);
            Console.WriteLine("Задача 1. Задан массив из случайных цифр на 15 элементов. На вход подаётся трёхзначное натуральное число.\n" +
                              "Напишите программу, которая определяет, есть в массиве последовательность из трёх элементов, совпадающая с введённым числом.");
            Console.Write("Заполненный массив: ");
            Helpers.PrintArray(numbers);
            int number = 0;
            do 
            {
                try
                {
                    Console.Write("Введите натуральное число: ");
                    number = Convert.ToInt32(Console.ReadLine());
                    if (number < 1) throw new Exception($"Число {number} не является натуральным.");
                }
                catch (Exception error)
                {
                    Console.WriteLine($"Ошибка: {error.Message}");
                }
            }
            while (number < 1);
            Console.WriteLine($"В массиве {(Helpers.FindSequence(numbers, number) ? "есть последовательность, совпадающая" : "нет последовательности, совпадающей")} с введённым числом.");
            Helpers.Hashes();
        }

        public static void Task2()
        {
            Console.WriteLine("Задача 2. На вход подаются два числа случайной длины. Найдите произведение каждого разряда первого числа на каждый разряд второго. Ответ запишите в массив.");
            int num1 = 0, num2 = 0;
            do
            {
                try
                {
                    Console.Write("Введите первое число: ");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите второе число: ");
                    num2 = Convert.ToInt32(Console.ReadLine());
                    if (num1 == 0 || num2 == 0) throw new Exception($"Одно из чисел или оба числа равны 0.");
                }
                catch (Exception error)
                {
                    Console.WriteLine($"Ошибка: {error.Message}");
                }
            } while (num1 == 0 || num2 == 0);
            int size = ((int)Math.Floor(Math.Log10(num1)) + 1) * ((int)Math.Floor(Math.Log10(num2)) + 1);
            int[] numbers = new int[size];
            Helpers.CartesianProduct(numbers, num1, num2);
            Helpers.PrintArray(numbers);
            Helpers.Hashes();
        }

        public static void Task3()
        {
            Console.WriteLine("Задача 3. Найдите все числа от 1 до 1000000, сумма цифр которых в три раза меньше их произведений. Подсчитайте их количество.");
            int result = Helpers.FindNumbers();
            Console.WriteLine($"Количество подходящих чисел: {result}");
            Helpers.Hashes();
        }

        public static void Task3Alt()
        {
            Console.WriteLine("Задача 3. Найдите все числа от 1 до 1000000, сумма цифр которых в три раза меньше их произведений. Подсчитайте их количество.");
            int count = Enumerable.Range(1, 1000000).Where(x => Helpers.FindNumbersAlt(x)).Count();
            Console.WriteLine($"Количество подходящих чисел: {count}");
            Helpers.Hashes();
        }

        public static void Task1Advanced()
        {
            Console.WriteLine("Задача 1*. Дан массив массивов, состоящих из натуральных чисел, размер которого 5.\n" +
                              "Для каждого элемента-массива требуется найти сумму его элементов и вывести массив с наибольшей суммой.\n"+
                              "Если таких массивов несколько, вывести массив с наименьшим индексом.");
            int[][] numArrays = new int[5][];
            for (int count = 0; count < numArrays.GetLength(0); count++)
            {
                numArrays[count] = new int[10];
                Helpers.FillArray(numArrays[count], 1, 100);
            }
            for (int count = 0; count < numArrays.GetLength(0); count++)
            {
                Console.Write($"Массив с индексом {count}: ");
                Helpers.PrintArray(numArrays[count]);
            }
            int max = Helpers.FindMaxSum(numArrays);
            Console.Write($"Массив с наибольшей суммой элементов – это массив с индексом {max}: ");
            Helpers.PrintArray(numArrays[max]);
            Helpers.Hashes();
        }
    }
}