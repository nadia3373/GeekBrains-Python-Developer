using System;
using System.Linq;

namespace Homework
{
    class Tasks
    {
        public static void Task41()
        {
            Console.Write("Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь. 0, 7, 8, -2, -2 -> 2 1, -7, 567, 89, 223-> 4.\n" +
                          "Введите числа через пробел: ");
            Console.WriteLine($"Количество введённых чисел > 0: {Console.ReadLine().Split(' ').Where(number => Convert.ToInt32(number) > 0).Count()}");
            Helpers.Hashes();
        }

        public static void Task43()
        {
            Console.WriteLine("Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2;\n" +
                              "значения b1, k1, b2 и k2 задаются пользователем. b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5).");
            double[,] coefficients = new double[2, 2];
            for (int count = 0; count < coefficients.GetLength(0); count++)
            {
                for (int index = 0; index < coefficients.GetLength(1); index++)
                {
                    Console.Write($"Введите коэффициент {(count == 0 ? index == 0 ? "b1" : "k1" : index == 0 ? "b2" : "k2")}: ");
                    coefficients[count, index] = Convert.ToDouble(Console.ReadLine());
                }
            }
            double[] answer = new double[2];
            if (Helpers.SolveEquations(coefficients, answer)) Console.WriteLine($"Координаты точки пересечения прямых – x: {Math.Round(answer[0], 2)}, y: {Math.Round(answer[1], 2)}.");
            else Console.WriteLine("Решений нет или их бесконечное множество.");
            Helpers.Hashes();
        }
    }
}