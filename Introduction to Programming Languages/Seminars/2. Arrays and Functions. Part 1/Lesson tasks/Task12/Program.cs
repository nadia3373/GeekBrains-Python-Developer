// Напишите программу, которая будет принимать на вход два числа и выводить, является ли второе число кратным первому.
// Если число 2 не кратно числу 1, то программа выводит остаток от деления.

void Divisible()
{
    Console.Write("Введите первое число: ");
    int first = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите второе число: ");
    int second = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(first % second == 0 ? "кратно" : "не кратно, остаток: " + first % second);
}

Divisible();