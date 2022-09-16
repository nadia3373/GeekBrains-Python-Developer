// Напишите программу, которая принимает на вход три числа и выдаёт максимальное из этих чисел.

// Запросить ввод 3 чисел, записать их в массив.
int [] numbers = new int[3];
for (int count = 0; count < numbers.Length; count++)
{
    Console.Write("Введите число: ");
    numbers[count] = Convert.ToInt32(Console.ReadLine());
}
// Отобразить максимальное число из массива.
Console.WriteLine("Максимальное число: " + numbers.Max());