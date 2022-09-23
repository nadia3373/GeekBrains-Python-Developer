// Напишите программу, которая принимает на вход число и проверяет, кратно ли оно одновременно 7 и 23.

void Divisible()
{
    Console.Write("Введите число: ");
    int number = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(number % 7 == 0 && number % 23 == 0 ? "да" : "нет");
}

Divisible();