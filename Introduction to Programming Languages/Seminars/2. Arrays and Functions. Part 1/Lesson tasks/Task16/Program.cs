// Напишите программу, которая принимает на вход два числа и проверяет, является ли одно число квадратом другого

void Squares()
{
    Console.Write("Введите первое число: ");
    int first = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите второе число: ");
    int second = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(first > second ? first / second == second ? "да" : "нет" : first * first == second ? "да" : "нет");
}

Squares();