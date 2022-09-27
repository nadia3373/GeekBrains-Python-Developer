// Задача 28: Напишите программу, которая принимает на вход число N и выдаёт произведение чисел от 1 до N.

Console.Write("Введите число: ");
int number = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(number >= 0 ? $"Факториал числа {number} = {Factorial(number)}" : "Введите число >= 0.");
int Factorial(int number)
{
    return number == 1 || number == 0 ? 1 : number * Factorial(number - 1);
}