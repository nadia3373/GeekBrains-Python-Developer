//Задача 30: Напишите программу, которая выводит массив из 8 элементов, заполненный нулями и единицами в случайном порядке.

Random random = new Random();
int[] numbers = new int[8];
for (int count = 0; count < numbers.Length; count++) numbers[count] = random.Next(0, 2);
foreach (int element in numbers) Console.WriteLine(element);