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

        #region Task64&64Alt
        public static void PrintNumbers(int a, int b = 1, string type = null)
        {
            if (a == b)
            {
                if (type == "divby3")
                {
                    if (a % 3 == 0) Console.Write($"{a}");
                }
                else Console.WriteLine(a);
                return;
            }
            else
            {
                if (type == "divby3")
                {
                    if (a % 3 == 0) Console.Write($"{a} ");
                    a = a % 3 == 0 && a + 3 <= b ? a + 3 : a + 1;
                }
                else
                {
                    Console.Write($"{a}, ");
                    a = a < 1 ? a + 1 : a - 1;
                }
                PrintNumbers(a, b, type);
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