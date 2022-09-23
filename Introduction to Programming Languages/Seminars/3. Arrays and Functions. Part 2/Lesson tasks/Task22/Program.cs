// Напишите программу, которая принимает на вход число (N) и выдаёт таблицу квадратов чисел от 1 до N.

Console.Write("Введите число N: ");
int number = Math.Abs(Convert.ToInt32(Console.ReadLine()));
string result = "";
for (int count = 1; count <= number; count++) result += Math.Pow(count, 2) + ", ";
Console.WriteLine($"{number} -> {result.Remove(result.Length -2)}");