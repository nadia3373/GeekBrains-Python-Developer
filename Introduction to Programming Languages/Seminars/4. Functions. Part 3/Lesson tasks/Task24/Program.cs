// Задача 24: Напишите программу, которая принимает на вход число (А) и выдаёт сумму чисел от 1 до А.

Console.Write($"Введите число: ");
int number = Math.Abs(Convert.ToInt32(Console.ReadLine()));
Console.WriteLine($"Сумма чисел от 1 до {number} = {number * (number + 1) / 2}");