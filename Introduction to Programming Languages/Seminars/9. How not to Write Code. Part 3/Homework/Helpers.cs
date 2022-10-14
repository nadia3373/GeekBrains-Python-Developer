using System;

namespace Homework
{
    class Helpers
    {
        #region Common
        public static void Hashes()
        {
            Console.WriteLine();
            for (int count = 0; count < Console.WindowWidth; count++) Console.Write("#");
            Console.WriteLine("\n");
        }

        public static (int m, int n) TakeInput()
        {
            Random random = new Random();
            (int m, int n) numbers = (0, 0);
            if (Console.ReadKey().Key == ConsoleKey.M)
            {
                Console.Write("\nВведите m: ");
                numbers.m = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите n: ");
                numbers.n = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                Console.WriteLine();
                numbers = (random.Next(1, 100), random.Next(1, 100));
            }
            return numbers;
        }
        #endregion

        #region Task64
        public static void PrintElements(int a, int b)
        {
            if (a == b)
            {
                if (a % 3 == 0) Console.Write($"{a}");
                return;
            }
            else
            {
                if (a % 3 == 0) Console.Write($"{a} ");
                a = a % 3 == 0 && a + 3 <= b ? a + 3 : a + 1;
                PrintElements(a, b);
            }
        }
        #endregion

        #region Task64Alt
        public static void PrintNumbers(int num)
        {
            if (num == 1)
            {
                Console.WriteLine(num);
                return;
            }
            else
            {
                Console.Write($"{num}, ");
                if (num < 1) PrintNumbers(num + 1);
                else PrintNumbers(num - 1);
            }
        }
        #endregion

        #region Task66
        public static int SumElements(int num1, int num2, int count)
        {
            count += num1;
            if (num1 == num2) return count;
            else return SumElements(num1 + 1, num2, count);
        }
        #endregion

        #region Task68
        public static int Ackermann(int m, int n)
        {
            if (m == 0) return n + 1;
            if (m > 0 && n == 0) return Ackermann(m - 1, 1);
            else return Ackermann(m - 1, Ackermann(m, n - 1));
        }
        #endregion
    }
}