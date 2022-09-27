// Задача 26: Напишите программу, которая принимает на вход число и выдаёт количество цифр в числе.

Console.Write("Введите число: ");
int number = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"В числе {number} {(number == 0 ? 1 : $"{(int)Math.Log10(Math.Abs(number)) + 1}")} цифр.");